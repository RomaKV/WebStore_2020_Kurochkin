using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.WebStore.DomainNew.Dto;
using Common.WebStore.DomainNew.Entities;
using Common.WebStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.WebStore.Infrastructure.Interfaces;

namespace Services.WebStore.ServicesHosting.Controllers
{
    [Produces("application/json")]
    [Route("api/orders")]  
    public class OrdersApiController : ControllerBase, IOrdersService
    {
        private readonly IOrdersService orderService;

        public OrdersApiController(IOrdersService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost("create")]
        public OrderDto CreateOrder([FromBody]CreateOrderDto order)
        {
           return this.orderService.CreateOrder(order);
        }

        [HttpGet("{id}"), ActionName("Get")]
        public OrderDto GetOrderById(int id)
        {
           return this.orderService.GetOrderById(id);
        }

        [HttpPost("user/{userName}")]
        public IEnumerable<OrderDto> GetUserOrders(string userName)
        {
            return this.orderService.GetUserOrders(userName);
        }
    }
}
