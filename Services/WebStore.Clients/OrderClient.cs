using Common.WebStore.DomainNew.Dto;
using Microsoft.Extensions.Configuration;
using Services.WebStore.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Net.Http;

namespace Services.WebStore.Clients
{
    public class OrderClient : BaseClient, IOrdersService
    {
        public OrderClient(IConfiguration configuration) : base(configuration)
        {
            this.ServiceAddress = "api/orders";
        }

        protected override string ServiceAddress { get; }

        public OrderDto CreateOrder(CreateOrderDto order)
        {

            var orderModel = Post($"{this.ServiceAddress}", order).
               Content.ReadAsAsync<OrderDto>().Result;


            return orderModel;                 
        }

        public OrderDto GetOrderById(int id)
        {
           return  this.Get<OrderDto>($"{this.ServiceAddress}/{id}");
        }

        public IEnumerable<OrderDto> GetUserOrders(string userName)
        {
           return this.Get<List<OrderDto>>($"{this.ServiceAddress}/user/{userName}");
        }
    }
}
