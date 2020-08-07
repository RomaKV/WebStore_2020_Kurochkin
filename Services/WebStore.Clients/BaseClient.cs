using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;

namespace Services.WebStore.Clients
{
    public abstract class BaseClient
    {
        public HttpClient Client { get; set; }
        protected abstract string ServiceAddress { get; set; }
        public BaseClient(IConfiguration configuration)
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri(configuration["clientAddress"])
            };

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
