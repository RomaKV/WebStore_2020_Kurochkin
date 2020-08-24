using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Common.WebStore.DomainNew.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.WebStore.Infrastructure.Interfaces;

namespace UI.WebStore.ViewComponents
{
    public class BreadCrumbsViewComponent : ViewComponent
    {
        private readonly IProductService productService;

        public BreadCrumbsViewComponent(IProductService productService)
        {
            this.productService = productService;
        }
        
        
        public IViewComponentResult Invoke(BreadCrumbType type, int id, BreadCrumbType fromType)
        {
            if (!Enum.IsDefined(typeof(BreadCrumbType), type))
            {
                throw new InvalidEnumArgumentException(nameof(type),
                    (int)type, typeof(BreadCrumbType));
            }

            if (!Enum.IsDefined(typeof(BreadCrumbType), fromType))
            {
                throw new InvalidEnumArgumentException(nameof(fromType),
                    (int)type, typeof(BreadCrumbType));
            }

            switch (type)
            {
                case BreadCrumbType.Category:
                    var category = this.productService.GetCategoryById(id);
                    return View(new List<BreadCrumbViewModel>
                    {
                        new BreadCrumbViewModel
                        {
                            BreadCrumbType = type,
                            Id = id.ToString(),
                            Name = category.Name
                        }
                    });
                case BreadCrumbType.Brand:
                    var brand = this.productService.GetBrandById(id);
                    return View(new List<BreadCrumbViewModel>
                    {
                        new BreadCrumbViewModel
                        {
                            BreadCrumbType = type,
                            Id = id.ToString(),
                            Name = brand.Name
                        }
                    });

                case BreadCrumbType.Item:
                    var item = GetItemBredCrumbs(id, fromType, type);
                    return View(item);
                case BreadCrumbType.None:
                default:
                    return View(new List<BreadCrumbViewModel>());
            }

        }

        private IEnumerable<BreadCrumbViewModel> GetItemBredCrumbs(int id, BreadCrumbType fromType, BreadCrumbType type)
        {
            var item = this.productService.GetProductById(id);
            var crumbs = new List<BreadCrumbViewModel>();
            if (fromType == BreadCrumbType.Category)
            {
                crumbs.Add(new BreadCrumbViewModel
                {
                    BreadCrumbType = fromType,
                    Id = item.Brand?.Id.ToString(),
                    Name = item.Category?.Name ?? ""
                });
            }
            else
            {
                crumbs.Add(new BreadCrumbViewModel
                {
                    BreadCrumbType = fromType,
                    Id = item.Brand?.Id.ToString(),
                    Name = item.Brand?.Name ?? ""
                });

            }

            crumbs.Add(new BreadCrumbViewModel
            {
                BreadCrumbType = type,
                Id = item.Brand?.Id.ToString(),
                Name = item?.Name ?? ""
            });


            return crumbs;

        }
    }
}
