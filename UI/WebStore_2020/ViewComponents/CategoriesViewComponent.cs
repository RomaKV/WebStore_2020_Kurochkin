using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Common.WebStore.DomainNew.ViewModels;
using Common.WebStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.WebStore.Infrastructure.Interfaces;

namespace UI.WebStore.ViewComponents
{
    //[ViewComponent(Name = "Categories")]
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public CategoriesViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            int.TryParse(categoryId, out var categoryIdInt);
            
            var _categories = GetCategories(categoryIdInt, out var parentCategoryId);
            
            return View(  new CategoryCompleteViewModel
                          {
                           Category = _categories,
                           CurrentCategoryId = categoryIdInt,
                           CurrentParentCategoryId = parentCategoryId
                          }
            );
        }

        private List<CategoryViewModel> GetCategories(int? categoryId, out int? parentCategoryId)
        {

            parentCategoryId = null;
            
            var categories = _productService.GetCategories();
            // получим и заполним родительские категории
            var parentSections = categories.Where(p => !p.ParentId.HasValue).ToArray();
            var parentCategories = new List<CategoryViewModel>();
            foreach (var parentCategory in parentSections)
            {
                parentCategories.Add(new CategoryViewModel()
                {
                    Id = parentCategory.Id,
                    Name = parentCategory.Name,
                    Order = parentCategory.Order,
                    ParentCategory = null
                });
            }

            // получим и заполним дочерние категории
            foreach (var CategoryViewModel in parentCategories)
            {
                var childCategories = categories.Where(c => c.ParentId == CategoryViewModel.Id);
                foreach (var childCategory in childCategories)
                {

                    if (childCategory.Id == categoryId)
                    {
                        parentCategoryId = CategoryViewModel.Id;

                    }
                    
                    
                    CategoryViewModel.ChildCategories.Add(new CategoryViewModel()
                    {
                        Id = childCategory.Id,
                        Name = childCategory.Name,
                        Order = childCategory.Order,
                        ParentCategory = CategoryViewModel
                    });
                }
                CategoryViewModel.ChildCategories = CategoryViewModel.ChildCategories.OrderBy(c => c.Order).ToList();
            }
            parentCategories = parentCategories.OrderBy(c => c.Order).ToList();
            return parentCategories;
        }

    }
}