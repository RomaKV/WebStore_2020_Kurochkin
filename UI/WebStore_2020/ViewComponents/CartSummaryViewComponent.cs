using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.WebStore.Infrastructure.Interfaces;

namespace UI.WebStore.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private ICartService cartService;
        
        public CartSummaryViewComponent(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public IViewComponentResult Invoke() => View(cartService.TransformCart());

    }
}
