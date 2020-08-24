using Common.WebStore.Domain.Entities;
using Common.WebStore.DomainNew.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace Common.WebStore.DomainNew.Helpers
{
    public static class ProductMapper
    {
        public static ProductDto ToDto(this Product p)
        {
            if (p == null)
            {
                return null;
            }
            
            
            var product = new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Order = p.Order,
                Price = p.Price,
                ImageUrl = p.ImageUrl
            };
            
            if (p.Brand != null)
            {
                product.Brand = new BrandDto
                {
                    Id = (int)p.BrandId,
                    Name = p.Brand.Name
                };
            }

            product.Category = new SectionDto
            {
                Id = p.CategoryId,
                Name =  p?.Category?.Name ?? ""
            };

            return product;
        }
    }
}
