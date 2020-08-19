using Common.WebStore.DomainNew.Dto;
using Common.WebStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.WebStore.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using UI.WebStore.Controllers;
using Xunit;

namespace WebStore.Tests
{
    public class CartControllerTest
    {
        private readonly Mock<ICartService> mockCartService;
        private readonly Mock<IOrdersService> mockOrderService;
        private readonly CartController controller;

        public CartControllerTest()
        {
            this.mockCartService = new Mock<ICartService>();
            this.mockOrderService = new Mock<IOrdersService>();
            this.controller = new CartController(this.mockCartService.Object, this.mockOrderService.Object);
        }

        [Fact]
        public void CheckOut_ModelState_Invalid_Returns_ViewModel()
        {
            // Arrange
            this.controller.ModelState.AddModelError("error", "InvalidModel");

            // Act
            var result = this.controller.CheckOut(new OrderViewModel { Name = "test" });

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<OrderDetailsViewModel>(viewResult.ViewData.Model);
            Assert.Equal("test", model.OrderViewModel.Name);
        }

        [Fact]
        public void CheckOut_Calls_Service_And_Return_Redirect()
        {
            // Arrange
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
               new Claim(ClaimTypes.NameIdentifier, "1"),

            }));

            this.mockCartService
                .Setup(c => c.TransformCart())
                .Returns(new CartViewModel
                {
                    Items = new Dictionary<ProductViewModel, int>()
                    {
                       {new ProductViewModel(), 1}
                    }
                });

            this.mockOrderService
                .Setup(o => o.CreateOrder(
                    It.IsAny<CreateOrderDto>(),
                    It.IsAny<string>()))
                .Returns(new OrderDto { Id = 1 });

            this.controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = user
                }
            };

            // Act
            var result = this.controller.CheckOut(new OrderViewModel
            {
                Name = "test",
                Address = "",
                Phone = ""
            });

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal("OrderConfirmed", redirectResult.ActionName);
            Assert.Equal(1, redirectResult.RouteValues["id"]);

        }
    }
}

