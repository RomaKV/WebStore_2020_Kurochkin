﻿using Common.WebStore.Domain.Entities.Base;
using Common.WebStore.Domain.Entities.Base.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.WebStore.Domain.Entities
{
    [Table("Products")]
    public class Product : NamedEntity , IOrderedEntity
    {
        public int Order { get; set; }
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }

        [ForeignKey("CategoryId")] // не обязательно в целом
        public virtual Category Category { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

    }

}
