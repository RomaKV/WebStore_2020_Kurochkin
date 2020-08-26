using Common.WebStore.Domain;
using Common.WebStore.Domain.Entities;
using Common.WebStore.DomainNew.Dto;
using Common.WebStore.ViewModels;
using Microsoft.Extensions.Configuration;
using Services.WebStore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
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

        public Brand GetBrandById(int id)
        {
            return Get<Brand>($"{this.ServiceAddress}/brands/{id}");
        }

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
            return Get<ProductDto>($"{this.ServiceAddress}/{id}");
        }

        public PagedProductDto GetProducts(ProductFilter filter)
        {
            return Post(this.ServiceAddress, filter).
                Content.ReadAsAsync<PagedProductDto>().Result;
           
        }

        public Category GetCategoryById(int id)
        {
            return Get<Category>($"{this.ServiceAddress}/categories/{id}");
        }
    }
}
