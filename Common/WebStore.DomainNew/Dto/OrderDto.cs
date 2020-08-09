using Common.WebStore.Domain.Entities.Base;
using Common.WebStore.Domain.Entities.Base.Interfaces;
using Common.WebStore.DomainNew.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.WebStore.DomainNew.Dto
{
    public class OrderDto : INamedEntity
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        //public IEnumerable<OrderItemDto> OrderItems { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

       
    

