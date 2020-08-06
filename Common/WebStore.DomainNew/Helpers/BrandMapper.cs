using Common.WebStore.Domain.Entities;
using Common.WebStore.DomainNew.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.WebStore.DomainNew.Helpers
{
    public static class BrandMapper
    {
        public static BrandDto ToDto(this Brand p)
        {
            return new BrandDto
            {
                Id = p.Id,
                Name = p.Name,               
            };
        }
    }
}
