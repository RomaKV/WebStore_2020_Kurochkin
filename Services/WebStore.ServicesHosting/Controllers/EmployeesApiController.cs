using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.WebStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.WebStore.Infrastructure.Interfaces;

namespace Services.WebStore.ServicesHosting.Controllers
{
    [Produces("application/json")]
    [Route("api/employees")]
    //[ApiController]
    //[Authorize]
    public class EmployeesController : ControllerBase, IEmployeesService
    {
        private readonly IEmployeesService employeesService;
        public EmployeesController(IEmployeesService employeesService)
        {
            this.employeesService = employeesService;
        }

        [HttpPost, ActionName("Post")]
        public void AddNew([FromBody] EmployeeViewModel model)
        {
            this.employeesService.AddNew(model);
        }

        [NonAction]
        public void Commit()
        {
            
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.employeesService.Delete(id);
        }

        [HttpGet, ActionName("Get")]
        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return this.employeesService.GetAll();
        }

        [HttpGet("{id}"), ActionName("Get")]
        public EmployeeViewModel GetById(int id)
        {
            return this.employeesService.GetById(id);
        }

        [HttpPut, ActionName("Put")]
        public EmployeeViewModel UpdateEmployee(int id, [FromBody] EmployeeViewModel entity)
        {
            return this.employeesService.UpdateEmployee(id, entity);
        }
    }
}
