using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RetailBankingProject.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RetailBankingProject.Services
{
    public class CustomerService : ICustomerService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public CustomerService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Creates customer 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        public async Task<HttpResponseMessage> CreateCustomer(Customer model)
        {


            using (HttpClient client = new HttpClient())
            {
                string token = _httpContextAccessor.HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //client.BaseAddress = new Uri("http://localhost:5002");
                client.BaseAddress = new Uri("https://mfpe-customerapi.azurewebsites.net");
                var jsonstring = JsonConvert.SerializeObject(model);
                var obj = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/Customers/createCustomer", obj);
                return response;
            }
        }
        /// <summary>
        /// gets the customer details from Customer API 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetCustomerDetails(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string token = _httpContextAccessor.HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //client.BaseAddress = new Uri("http://localhost:5002");
                client.BaseAddress = new Uri("https://mfpe-customerapi.azurewebsites.net");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));

                var response = await client.GetAsync("api/Customers/getCustomerDetails/" + id);
                return response;
            }
        }

        /// <summary>
        /// Gets all the customers from the Customer API
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetCustomers()
        {
            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://localhost:5002");
                client.BaseAddress = new Uri("https://mfpe-customerapi.azurewebsites.net");
                string token = _httpContextAccessor.HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));
                var response = await client.GetAsync("api/Customers/GetAllCustomers");
                return response;
            }
        }
    }
}
