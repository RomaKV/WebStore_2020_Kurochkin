using Common.WebStore.DomainNew.Dto;
using Common.WebStore.DomainNew.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Common.WebStore.DomainNew.Helpers
{
    public static class OrderMapper
    {
        public static OrderDto ToDto(this Order order)
        {
            if (order == null)
            {
                return null;
            }

            var result = new OrderDto
            {
                Address = order.Address,
                Date = order.Date,
                Phone = order.Phone,
                OrderItems = order?.OrderItems.Select(item => item.ToDto()).ToList()
            };

            return result;


        }
    }
}
