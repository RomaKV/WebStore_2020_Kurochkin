using Common.WebStore.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.WebStore.Infrastructure.Interfaces;

namespace UI.WebStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admins")]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductList()
        {
            var products = _productService.GetProducts(new ProductFilter());
            return View(products);
        }
    }
}