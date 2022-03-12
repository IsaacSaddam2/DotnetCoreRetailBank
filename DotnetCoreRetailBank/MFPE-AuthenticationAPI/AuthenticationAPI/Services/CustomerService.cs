﻿using AuthenticationAPI.Models;
using log4net;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace AuthenticationAPI.Repository
{
    public class CustomerService : ICustomerService
    {
        private readonly IConfiguration _configuration;
        private readonly ILog _logger = LogManager.GetLogger(typeof(CustomerService));


        public CustomerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public UserResponse CheckUser(UserRequest userRequest)
        {
            try
            {
                _logger.Info("Check User Called in Customer Service");
                using (HttpClient _client = new HttpClient())
                {
                    _client.BaseAddress = new Uri(_configuration["BaseUrl:Customer"]);
                    var payload = new StringContent(JsonConvert.SerializeObject(userRequest), Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = _client.PostAsync("api/customers/checkCredentials", payload).Result;
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var response = JsonConvert.DeserializeObject<UserResponse>(responseMessage.Content.ReadAsStringAsync().Result);
                        return response;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                throw;
            }


        }
    }
}
