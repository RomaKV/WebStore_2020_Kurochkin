using Common.WebStore.Domain.Entities.Base;
using System;
using System.Collections.ObjectModel;

namespace Common.WebStore.DomainNew.Entities
{
    public class Order : NamedEntity
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }

        public virtual User User { get; set; } // внешний ключ в БД
        public virtual Collection<OrderItem> OrderItems { get; set; }
    }
}