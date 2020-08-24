using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.WebStore.DomainNew.ViewModels;
using Common.WebStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.WebStore.Infrastructure.Interfaces;

namespace UI.WebStore.ViewComponents
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public BrandsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string brandId)
        {
            int.TryParse(brandId, out var brandIdInt);
            
            var brands = GetBrands();
            return View(new BrandCompleteViewModel
            {
                Brands = brands,
                CurrentBrandId = brandIdInt
            });
        }

        //public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        //{
        //    int.TryParse(categoryId, out var categoryIdInt);

        //    var _categories = GetCategories(categoryIdInt, out var parentCategoryId);

        //    return View(new CategoryCompleteViewModel
        //        {
        //            Category = _categories,
        //            CurrentCategoryId = categoryIdInt,
        //            CurrentParentCategoryId = parentCategoryId
        //        }
        //    );
        //}





        private IEnumerable<BrandViewModel> GetBrands()
        {
            var dbBrands = _productService.GetBrands();
            return dbBrands.Select(b => new BrandViewModel
            {
                Id = b.Id,
                Name = b.Name,
                //Order = b.Order,
                //ProductsCount = 0
            }).OrderBy(b => b.Order).ToList();
        }

    }
}
