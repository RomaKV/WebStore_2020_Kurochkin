using Common.WebStore.Domain;
using Common.WebStore.DomainNew.Dto;
using Common.WebStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.WebStore.Infrastructure.Interfaces;
using System.Linq;
using UI.WebStore.Controllers;
using Xunit;
using Assert = Xunit.Assert;


namespace WebStore.Tests
{
    public class CatalogControllerTests
    {
        //private readonly CatalogController controller;
        private readonly ProductDto[] testProducts;
        public CatalogControllerTests()
        {
            testProducts = new[]
            {
                new ProductDto {
                    Id = 1,
                    Name = "T-shirt",
                    ImageUrl = "111",
                    Order = 120,
                    Price = 1000,
                    Brand = new BrandDto()
                    {
                        Id =1,
                        Name = "Nike"
                    }
                },
                new ProductDto {
                    Id = 2,
                    Name = "Jacket",
                    ImageUrl = "222",
                    Order = 150,
                    Price = 2000,
                    Brand = new BrandDto()
                    {
                        Id =1,
                        Name = "Nike"
                    }
                }
            };

        }


        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void ProductDetails_Returns_View_With_Correct_Item(int index)
        {
            //Arrange
            var mockService = new Mock<IProductService>();
            mockService.Setup(p => p.GetProductById(this.testProducts[index].Id)).Returns(this.testProducts[index]);
            var controller = new CatalogController(mockService.Object);

            // Act
            var result = controller.ProductDetails(this.testProducts[index].Id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ProductViewModel>(viewResult.ViewData.Model);
            Assert.IsType<ProductViewModel>(model);
            Assert.Equal(this.testProducts[index].Name, model.Name);
            Assert.Equal(this.testProducts[index].Brand.Name, model.Brand);
            Assert.Equal(this.testProducts[index].ImageUrl, model.ImageUrl);
            Assert.Equal(this.testProducts[index].Id, model.Id);
            Assert.Equal(this.testProducts[index].Order, model.Order);
            Assert.Equal(this.testProducts[index].Price, model.Price);

        }

        [Fact]
        public void ProductDetails_Returns_NotFound()
        {
            var mockService = new Mock<IProductService>();
            mockService.Setup(p => p.GetProductById(10)).Returns((ProductDto)null);
            var controller = new CatalogController(mockService.Object);

            // Act
            var result = controller.ProductDetails(10);

            // Assert
            var viewResult = Assert.IsType<NotFoundResult>(result);
            var model = Assert.IsAssignableFrom<NotFoundResult>(viewResult);
            Assert.Equal(404, model.StatusCode);
        }

        [Fact]
        public void Shop_Method_Returns_Correct_View()
        {
            //Arrange
            var mockService = new Mock<IProductService>();
            mockService.Setup(p => p.GetProducts(It.IsAny<ProductFilter>())).Returns(this.testProducts);
            var controller = new CatalogController(mockService.Object);

            // Act
            var result = controller.Shop(3, 1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CatalogViewModel>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Products.Count());
            Assert.Equal(1, model.BrandId);
            Assert.Equal(3, model.CategoryId);

            Assert.True(CompareModel(
                model.Products.SingleOrDefault(m => m.Id.Equals(1)),
                new ProductViewModel
                {
                    Name = "T-shirt",
                    Order = 120,
                    Id = 1,
                    Price = 1000,
                    Brand = "Nike",
                    ImageUrl = "111"
                }
            ));
            Assert.True(CompareModel(
                model.Products.SingleOrDefault(m => m.Id.Equals(2)),
                new ProductViewModel
                {
                    Name = "Jacket",
                    Order = 150,
                    Id = 2,
                    Price = 2000,
                    Brand = "Nike",
                    ImageUrl = "222"
                }
            ));
        }
        private static bool CompareModel(ProductViewModel expected, ProductViewModel actual)
        {
            if (expected.Id != actual.Id)
            {
                return false;
            }
            else if (expected.Name != actual.Name)
            {
                return false;
            }
            else if (expected.ImageUrl != actual.ImageUrl)
            {
                return false;
            }
            else if (expected.Order != actual.Order)
            {
                return false;
            }
            else if (expected.Price != actual.Price)
            {
                return false;
            }
            else if (expected.Brand != actual.Brand)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



    }
}

