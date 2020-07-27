using Common.WebStore.DomainNew.Entities;
using System.Collections.Generic;
using UI.WebStore.Models;

namespace UI.WebStore.Infrastructure.Interfaces
{
    public interface IOrdersService
    {
        IEnumerable<Order> GetUserOrders(string userName);
        Order GetOrderById(int id);
        Order CreateOrder(OrderViewModel orderModel, CartViewModel transformCart, string userName);
    }
}
