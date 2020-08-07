using Common.WebStore.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.WebStore.DomainNew.Dto
{
    public class OrderItemDto: BaseEntity
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
      
    }
}
