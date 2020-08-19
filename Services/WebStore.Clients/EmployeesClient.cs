using Common.WebStore.ViewModels;
using Microsoft.Extensions.Configuration;
using Services.WebStore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.WebStore.Clients
{
    public class EmployeesClient : BaseClient, IEmployeesService
    {

        public EmployeesClient(IConfiguration configuration) : base(configuration)
        {
            this.ServiceAddress = "api/employees";
        }


        protected override string ServiceAddress { get;}

        public void AddNew(EmployeeViewModel model)
        {
            var list = this.Post<EmployeeViewModel>(this.ServiceAddress, model);
            return;
        }

        public void Commit()
        {
           // throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            this.Delete(id);
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            var list = this.Get<List<EmployeeViewModel>>(this.ServiceAddress);
            return list;
        }

        public EmployeeViewModel GetById(int id)
        {
            var list = this.Get<EmployeeViewModel>($"{this.ServiceAddress}/{id}");
            return list;
        }

        public EmployeeViewModel UpdateEmployee(int id, EmployeeViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
