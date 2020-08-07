using Common.WebStore.DomainNew.Dto;
using Common.WebStore.DomainNew.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.WebStore.DomainNew.Helpers
{
    public static class OrderItemMapper
    {

        public static OrderItemDto ToDto(this OrderItem orderItem)
        {

            if (orderItem == null)
            {
                return null;
            }

            var result = new OrderItemDto
            {
                Price = orderItem.Price,
                Quantity = orderItem.Quantity

            };

            return result;
        }
    }
}
