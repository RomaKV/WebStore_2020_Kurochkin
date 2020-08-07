using Microsoft.Extensions.Configuration;
using Services.WebStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.WebStore.Clients
{
    public class ValuesClient : BaseClient, IValuesService
    {
        
        public ValuesClient(IConfiguration configuration) : base(configuration)
        {
            this.ServiceAddress = "api/values";
        }
              
        
        protected override string ServiceAddress { get; set; } 
        
        public HttpStatusCode Delete(int id)
        {
           
            var response = this.Client.GetAsync($"{ServiceAddress}/delete/{id}").Result;

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteAsync(int id)
        {
            var response = await this.Client.GetAsync($"{ServiceAddress}/delete/{id}");

            return response.StatusCode;
        }

        public IEnumerable<string> Get()
        {
            var list = new List<string>();
            var response = this.Client.GetAsync($"{ServiceAddress}").Result;
            if (response.IsSuccessStatusCode)
            {
                list = response.Content.ReadAsAsync<List<string>>().Result;
            }

            return list;
        }

        public string Get(int id)
        {
            string list = string.Empty;
            var response = this.Client.GetAsync($"{ServiceAddress}/get/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                list = response.Content.ReadAsAsync<string>().Result;
            }

            return list;
        }

        public async Task<IEnumerable<string>> GetAsync()
        {
            var list = new List<string>();
            var response = await this.Client.GetAsync($"{ServiceAddress}");
            if (response.IsSuccessStatusCode)
            {
                list = await response.Content.ReadAsAsync<List<string>>();
            }

            return list;
        }

        public async Task<string> GetAsync(int id)
        {
            string list = string.Empty;
            var response = await this.Client.GetAsync($"{ServiceAddress}/get/{id}");
            if (response.IsSuccessStatusCode)
            {
                list = await response.Content.ReadAsAsync<string>();
            }

            return list;
        }

        public Uri Post(string value)
        {
            throw new NotImplementedException();
        }

        public Task<Uri> PostAsync(string value)
        {
            throw new NotImplementedException();
        }

        public HttpStatusCode Put(int id, string value)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> PutAsync(int id, string value)
        {
            throw new NotImplementedException();
        }
    }
}
