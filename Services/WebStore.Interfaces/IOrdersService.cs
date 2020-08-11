using Common.WebStore.DomainNew.Dto;
using Common.WebStore.DomainNew.Entities;
using Common.WebStore.ViewModels;
using System.Collections.Generic;

namespace Services.WebStore.Infrastructure.Interfaces
{
    public interface IOrdersService
    {
        IEnumerable<OrderDto> GetUserOrders(string userName);
        OrderDto GetOrderById(int id);
        OrderDto CreateOrder(CreateOrderDto order, string userName);
    }
}
