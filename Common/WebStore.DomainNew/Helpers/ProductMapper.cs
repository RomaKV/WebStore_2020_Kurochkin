using Common.WebStore.Domain.Entities;
using Common.WebStore.DomainNew.Dto;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Common.WebStore.DomainNew.Helpers
{
    public static class ProductMapper
    {
        public static ProductDto ToDto(this Product p)
        {
            return new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Order = p.Order,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Brand = p.BrandId.HasValue ? new BrandDto
                {
                    Id = p.Brand.Id,
                    Name = p.Brand.Name
                } : null

            };
        }
    }
}
