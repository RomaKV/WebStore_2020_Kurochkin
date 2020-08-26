using System.Collections.Generic;
using Common.WebStore.Domain;
using Common.WebStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.WebStore.Infrastructure.Interfaces;
using System.Linq;
using Common.WebStore.DomainNew.ViewModels;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.WebStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductService productService;

        private readonly IConfiguration configuration;

        public CatalogController(IProductService productService, IConfiguration configuration)
        {
            this.productService = productService;
            this.configuration = configuration;
        }

        public IActionResult Shop(int? categoryId, int? brandId, int page = 1)
        {
            var pageSize = int.Parse(this.configuration["PageSize"]);

            var products = GetProducts(categoryId, brandId, page, out int totalCount);

            var model = new CatalogViewModel()
            {
                BrandId = brandId,
                CategoryId = categoryId,
                Products = products,
                PageViewModel = new PageViewModel
                {
                    PageSize = pageSize,
                    PageNumber = page,
                    TotalItems = totalCount
                }
            };

            return View(model);
        }

        public IActionResult ProductDetails(int id)
        {
            var product = this.productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return View(new ProductViewModel
            {
                Id = product.Id,
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Order = product.Order,
                Price = product.Price,
                Brand = product.Brand?.Name ?? string.Empty
            });

        }

        public IActionResult GetFilteredItems(int? categoryId, int? brandId, int page = 1)
        {
            var productsModel = GetProducts(categoryId, brandId, page, out var totalCount);
            return PartialView("_Partial/_FeaturedItems", productsModel);

        }

        private IEnumerable<ProductViewModel> GetProducts(int? categoryId, int? brandId, int page,
            out int totalCount)
        {
            var pageSize = int.Parse(this.configuration["PageSize"]);

            var products = this.productService.GetProducts(
                new ProductFilter {BrandId = brandId, CategoryId = categoryId, Page = page, PageSize = pageSize});

            totalCount = products.TotalCount;

            return products.Products.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price,
                    Brand = p.Brand?.Name ?? string.Empty
                })
                .OrderBy(p => p.Order)
                .ToList();
        }
    
}
}
