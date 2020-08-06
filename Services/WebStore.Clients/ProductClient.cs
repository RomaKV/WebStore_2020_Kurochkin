using Common.WebStore.Domain;
using Common.WebStore.Domain.Entities;
using Common.WebStore.DomainNew.Dto;
using Common.WebStore.ViewModels;
using Microsoft.Extensions.Configuration;
using Services.WebStore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.WebStore.Clients
{
    public class ProductClient : BaseClient, IProductService
    {
        public ProductClient(IConfiguration configuration) : base(configuration)
        {
            this.ServiceAddress = "api/products";
        }

        protected override string ServiceAddress { get; }
   
        public IEnumerable<BrandDto> GetBrands()
        {
            return Get<List<BrandDto>>($"{this.ServiceAddress}/brands");
        }
       
        public IEnumerable<Category> GetCategories()
        {
            return Get<List<Category>>($"{this.ServiceAddress}/categories");
        }

        public ProductDto GetProductById(int id)
        {
            return Get<ProductDto>($"{this.ServiceAddress}/products/{id}");
        }

        public IEnumerable<ProductDto> GetProducts(ProductFilter filter)
        {
            return Get<List<ProductDto>>($"{this.ServiceAddress}/products");
        }


        
    }
}
