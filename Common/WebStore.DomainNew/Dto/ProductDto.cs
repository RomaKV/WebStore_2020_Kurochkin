using Common.WebStore.Domain.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.WebStore.DomainNew.Dto
{
    class ProductDto : INamedEntity, IOrderedEntity
    {
        public int Order { get; set;}
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public BrandDto Brand { get; set; }
        public string ImageUrl { get; set; }
    }
}
