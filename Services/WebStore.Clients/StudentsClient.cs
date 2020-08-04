using Common.WebStore.DomainNew.ApiModels;
using Microsoft.Extensions.Configuration;
using Services.WebStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services.WebStore.Clients
{
    public class StudentsClient : BaseClient, IStudentsService
    {
        public StudentsClient(IConfiguration configuration) : base(configuration)
        {
            this.ServiceAddress = "students/list";
        }

        protected override string ServiceAddress { get;}

        public HttpStatusCode Delete(int id)
        {
            var response = this.Client.GetAsync($"{ServiceAddress}/students/delete/{id}").Result;

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteAsync(int id)
        {
            var response = await this.Client.GetAsync($"{ServiceAddress}/students/delete/{id}");

            return response.StatusCode;
        }

        public IEnumerable<StudentModel> Get()
        {
            var list = new List<StudentModel>();
            var response = this.Client.GetAsync($"{ServiceAddress}").Result;
            if (response.IsSuccessStatusCode)
            {
                list = response.Content.ReadAsAsync<List<StudentModel>>().Result;
            }

            return list;
        }

        public StudentModel Get(int id)
        {
            StudentModel list = null;
            var response = this.Client.GetAsync($"{ServiceAddress}/students/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                list = response.Content.ReadAsAsync<StudentModel>().Result;
            }

            return list;
        }

        public async Task<IEnumerable<StudentModel>> GetAsync()
        {
            var list = new List<StudentModel>();
            var response = await this.Client.GetAsync($"{ServiceAddress}");
            if (response.IsSuccessStatusCode)
            {
                list = await response.Content.ReadAsAsync<List<StudentModel>>();
            }

            return list;
        }

        public async Task<StudentModel> GetAsync(int id)
        {
            StudentModel list = null;
            var response = await this.Client.GetAsync($"{ServiceAddress}/students/{id}");
            if (response.IsSuccessStatusCode)
            {
                list = await response.Content.ReadAsAsync<StudentModel>();
            }

            return list;
        }

        public Uri Post(StudentModel value)
        {
            throw new NotImplementedException();
        }

        public Task<Uri> PostAsync(StudentModel value)
        {
            throw new NotImplementedException();
        }

        public HttpStatusCode Put(int id, StudentModel value)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> PutAsync(int id, StudentModel value)
        {
            throw new NotImplementedException();
        }
    }
}
