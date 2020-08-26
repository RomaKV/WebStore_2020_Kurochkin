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
            
            var products = this.productService.GetProducts(
                new ProductFilter { BrandId = brandId, CategoryId = categoryId, Page = page, PageSize = pageSize});

            var model = new CatalogViewModel()
            {
                BrandId = brandId,
                CategoryId = categoryId,
                Products = products.Products.Select(p => new ProductViewModel
                        {
                          Id = p.Id,
                          ImageUrl = p.ImageUrl,
                          Name = p.Name,
                          Order = p.Order,
                          Price = p.Price,
                          Brand = p.Brand?.Name ?? string.Empty
                         }),
                PageViewModel = new PageViewModel{
                         PageSize = pageSize,
                         PageNumber = page,
                         TotalItems = products.TotalCount
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


    }
}
