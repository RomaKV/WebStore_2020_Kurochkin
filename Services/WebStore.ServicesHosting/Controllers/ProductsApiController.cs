using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.WebStore.Domain;
using Common.WebStore.Domain.Entities;
using Common.WebStore.DomainNew.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.WebStore.Infrastructure.Interfaces;

namespace Services.WebStore.ServicesHosting.Controllers
{
    [Produces ("application/json")]
    [Route("api/products")]   
    public class ProductsApiController : ControllerBase, IProductService
    {
        private readonly IProductService productService;

        public ProductsApiController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("brands")]
        public IEnumerable<BrandDto> GetBrands()
        {
            return this.productService.GetBrands();
        }

        [HttpGet("categories")]
        public IEnumerable<Category> GetCategories()
        {
            return this.productService.GetCategories();
        }

        [HttpGet("{id}"), ActionName("Get")]       
        public ProductDto GetProductById(int id)
        {
            
            return this.productService.GetProductById(id);
        }

        [HttpPost, ActionName("Post")]
        public IEnumerable<ProductDto> GetProducts(ProductFilter filter)
        {
            return this.productService.GetProducts(filter);
        }
    }
}
