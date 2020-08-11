using Common.WebStore.DomainNew.Dto;
using Common.WebStore.DomainNew.Entities;
using Common.WebStore.DomainNew.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.WebStore.DAL;
using Services.WebStore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebStore.Services
{
    public class SqlOrdersService : IOrdersService
    {
        private readonly WebStoreContext _context;
        private readonly UserManager<User> _userManager;

        public SqlOrdersService(WebStoreContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IEnumerable<OrderDto> GetUserOrders(string userName)
        {
            return _context.Orders
                .Include("User")
                .Include("OrderItems")
                .Where(x => x.User.UserName == userName)
                .Select(o => o.ToDto()).ToList();
        }

        public OrderDto GetOrderById(int id)
        {
            return _context.Orders
                .Include("User")
                .Include("OrderItems")
                .FirstOrDefault(x => x.Id == id).ToDto();
        }

        public OrderDto CreateOrder(CreateOrderDto order, string userName)
        {
            var user = _userManager.FindByNameAsync(userName).Result;

            using (var transaction = _context.Database.BeginTransaction())
            {
                var orderModel  = new Order()
                {
                    Address = order.Order.Address,
                    Name = order.Order.Name,
                    Date = DateTime.Now,
                    Phone = order.Order.Phone,
                    User = user
                };

                _context.Orders.Add(orderModel);

                foreach (var item in order.OrderItems)
                {
                   
                    var product = _context.Products.FirstOrDefault(p => p.Id.Equals(item.Id));

                    if (product == null)
                        throw new InvalidOperationException("Продукт не найден в базе");

                    var orderItem = new OrderItem()
                    {
                        Price = product.Price,
                        Quantity = item.Quantity,

                        Order = orderModel,
                        Product = product
                    };

                    _context.OrderItems.Add(orderItem);
                }

                _context.SaveChanges();
                transaction.Commit();

                return orderModel.ToDto();
            }
        }
    }
}
