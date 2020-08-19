using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.WebStore.Interfaces;
using UI.WebStore.Controllers;
using Xunit;

namespace WebStore.Tests
{
    public class HomeControllerTests
    {

        private readonly HomeController controller;
        
        public HomeControllerTests()
        {
            var mockService = new Mock<IValuesService>();
            mockService.Setup(c => c.GetAsync()).ReturnsAsync(new List<string>
            {
                "1", "2"
            });

            this.controller = new HomeController(mockService.Object);

        }


        [Fact]
        public async Task Index_Method_Returns_View_With_Values()
        {
            //Arrange and act
            var result = await this.controller.Index();

            //Assert

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<string>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void ContactUs_Returns_View()
        {
            //Arrange and act
            var result = this.controller.ContactUs();

            //Assert

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ErrorStatus_404_Redirects_toNotFound()
        {
            //Arrange and act
            var result = this.controller.ErrorStatus("404");
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            //Assert
            Assert.Null((redirectToActionResult.ControllerName));
            Assert.Equal("NotFound", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Checkout_Returns_View()
        {
            //Arrange and act
            var result = this.controller.Checkout();

            //Assert

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void BlogSingle_Returns_View()
        {
            //Arrange and act
            var result = this.controller.BlogSingle();

            //Assert

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Blog_Returns_View()
        {
            //Arrange and act
            var result = this.controller.Blog();

            //Assert

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void NotFound_Returns_View()
        {
            //Arrange and act
            var result = this.controller.NotFound();

            //Assert

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ErrorStatus_Another_Returns_Content_Result()
        {
            //Arrange and act
            var result = this.controller.ErrorStatus("500");

            //Assert
            var contentResult =  Assert.IsType<ContentResult>(result);
            Assert.Equal("Статусный код ошибки: 500", contentResult.Content);
        }


    }
}
