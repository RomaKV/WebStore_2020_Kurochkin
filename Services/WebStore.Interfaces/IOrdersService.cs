using Common.WebStore.DomainNew.Entities;
using Common.WebStore.ViewModels;
using System.Collections.Generic;

namespace Services.WebStore.Infrastructure.Interfaces
{
    public interface IOrdersService
    {
        IEnumerable<Order> GetUserOrders(string userName);
        Order GetOrderById(int id);
        Order CreateOrder(OrderViewModel orderModel, CartViewModel transformCart, string userName);
    }
}
