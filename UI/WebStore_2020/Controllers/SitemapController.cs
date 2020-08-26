using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.WebStore.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.WebStore.Infrastructure.Interfaces;
using SimpleMvcSitemap;

namespace Services.WebStore.ServicesHosting.Controllers
{
    

    public class SitemapController : Controller
    {
        private readonly IProductService productService;
        public SitemapController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var nodes = new List<SitemapNode>
            {
                new SitemapNode(Url.Action("Index", "Home")),
                new SitemapNode(Url.Action("Shop", "Catalog")),
                new SitemapNode(Url.Action("BlogSingle", "Home")),
                new SitemapNode(Url.Action("Blog", "Home")),
                new SitemapNode(Url.Action("ContactUs", "Home")),
            };

            var categories = this.productService.GetCategories();
            foreach (var category in categories)
            {
                if (category.ParentId.HasValue)
                {
                    nodes.Add(new SitemapNode(Url.Action("Shop", "Catalog",
                        new {categoryId = category.Id})));
                }

               

            }

            var brands = this.productService.GetBrands();
            foreach (var brand in brands)
            {
                
                    nodes.Add(new SitemapNode(Url.Action("Shop", "Catalog",
                        new { brandId =  brand.Id })));
                    
            }

            var products = this.productService.GetProducts(
                new ProductFilter());

            foreach (var productDto in products.Products)
            {

                nodes.Add(new SitemapNode(Url.Action("ProductDetails", "Catalog",
                    new { id = productDto.Id })));

            }




            return new SitemapProvider()
                .CreateSitemap(new SitemapModel(nodes));
        }
    }
}
