using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.WebStore.DomainNew.Entities;
using Common.WebStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.WebStore.Infrastructure.Interfaces;

namespace Services.WebStore.ServicesHosting.Controllers
{
    
    [Route("api/orders")]
    [Produces("application/json")]
    public class OrdersApiController : ControllerBase, IOrdersService
    {
        private readonly IOrdersService orderService;

        public OrdersApiController(IOrdersService orderService)
        {
            this.orderService = orderService;
        }
              
        [HttpPost("create")]
        public Order CreateOrder(OrderViewModel orderModel, CartViewModel transformCart, string userName)
        {
           return this.CreateOrder(orderModel, transformCart, userName);
        }

        [HttpGet("{id}"), ActionName("Get")]
        public Order GetOrderById(int id)
        {
           return this.GetOrderById(id);
        }

        [HttpPost("user/{userName}")]
        public IEnumerable<Order> GetUserOrders(string userName)
        {
            return this.GetUserOrders(userName);
        }
    }
}
