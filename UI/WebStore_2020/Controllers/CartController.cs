using Common.WebStore.DomainNew.Dto;
using Common.WebStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.WebStore.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace UI.WebStore.Controllers
{
    public class CartController: Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrdersService _ordersService;

        public CartController(ICartService cartService, IOrdersService ordersService)
        {
            _cartService = cartService;
            _ordersService = ordersService;
        }

        public IActionResult Details()
        {
            var model = new OrderDetailsViewModel()
            {
                CartViewModel = _cartService.TransformCart(),
                OrderViewModel = new OrderViewModel()
            };


            return View(model);
        }

        public IActionResult DecrementFromCart(int id)
        {
            _cartService.DecrementFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveAll()
        {
            _cartService.RemoveAll();
            return RedirectToAction("Details");
        }

        public IActionResult AddToCart(int id, string returnUrl)
        {
            _cartService.AddToCart(id);
            return Redirect(returnUrl);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CheckOut(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var createOrderDto = new CreateOrderDto
                {
                    Order = model,
                    OrderItems = new List<OrderItemDto>()                 
                };

                foreach(var orderItem in _cartService.TransformCart().Items)
                {
                    createOrderDto.OrderItems.Add(new OrderItemDto
                    {
                        Id = orderItem.Key.Id,
                        Price = orderItem.Key.Price,
                        Quantity = orderItem.Value
                    });
                }



                var orderResult = _ordersService.CreateOrder(createOrderDto, User.Identity.Name);
                 
                _cartService.RemoveAll();
                return RedirectToAction("OrderConfirmed", new { id = orderResult.Id });
            }

            var detailsModel = new OrderDetailsViewModel()
            {
                CartViewModel = _cartService.TransformCart(),
                OrderViewModel = model
            };

            return View("Details", detailsModel);
        }

        public IActionResult OrderConfirmed(int id)
        {
            @ViewBag.OrderId = id;
            return View();
        }
    }
}
