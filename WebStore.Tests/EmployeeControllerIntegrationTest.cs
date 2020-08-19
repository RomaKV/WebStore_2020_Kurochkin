using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.WebStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.WebStore.Clients;
using UI.WebStore.Controllers;
using Xunit;

namespace WebStore.Tests
{
    public class EmployeeControllerIntegrationTest
    {
        private readonly  EmployeeController controller;

        public EmployeeControllerIntegrationTest()
        {
            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
            {
                { "ClientAddress", "http://localhost:49217"},
            });
          

            this.controller = new EmployeeController(new EmployeesClient(builder.Build()));
        }
        
        [Fact]
        public  void Index_Method_Returns_All_Employees()
        {
            //Arrange and act
            var result = this.controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<EmployeeViewModel>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
           
        }

        [Theory]
        [InlineData(1, "Иван", 22)]
        [InlineData(2, "Владислав", 35)]
        public void Index_Method_Returns_Details_Employee(int id, string firstName, int age )
        {
            //Arrange and act
            var result = this.controller.Details(id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<EmployeeViewModel>(viewResult.ViewData.Model);
            Assert.Equal(firstName, model.FirstName);
            Assert.Equal(age, model.Age);

        }
    }
}
