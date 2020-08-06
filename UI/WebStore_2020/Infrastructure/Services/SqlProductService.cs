﻿using Common.WebStore.Domain;
using Common.WebStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Services.WebStore.DAL;
using Services.WebStore.Infrastructure.Interfaces;
using Common.WebStore.DomainNew.Dto;
using Common.WebStore.DomainNew.Helpers;

namespace UI.WebStore.Infrastructure.Services
{
    public class SqlProductService : IProductService
    {
        private readonly WebStoreContext _context;

        public SqlProductService(WebStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public IEnumerable<BrandDto> GetBrands()
        {
            return _context.Brands.Select(b => b.ToDto()).ToList();
        }

        public IEnumerable<ProductDto> GetProducts(ProductFilter filter)
        {
            var query = _context.Products
                .Include(p => p.Category) // жадная загрузка (Eager Load) для категорий
                .Include(p => p.Brand) // жадная загрузка (Eager Load) для брендов
                .AsQueryable();

            if (filter.BrandId.HasValue)
                query = query.Where(c => c.BrandId.HasValue && c.BrandId.Value.Equals(filter.BrandId.Value));
            if (filter.CategoryId.HasValue)
                query = query.Where(c => c.CategoryId.Equals(filter.CategoryId.Value));

            return query.Select(p => p.ToDto()).ToList();
        }

        public ProductDto GetProductById(int id)
        {
            return _context.Products
                .Include(p => p.Category) // жадная загрузка (Eager Load) для категорий
                .Include(p => p.Brand) // жадная загрузка (Eager Load) для брендов
                .FirstOrDefault(p => p.Id == id).ToDto();

        }
    }
}
