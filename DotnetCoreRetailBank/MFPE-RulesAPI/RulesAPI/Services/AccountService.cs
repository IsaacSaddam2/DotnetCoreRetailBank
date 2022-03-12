using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using RulesAPI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace RulesAPI.Repository
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILog _logger = LogManager.GetLogger(typeof(AccountService));

        public AccountService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }


        public AccountDetails GetAccount(int accountId)
        {
            try
            {
                _logger.Info("Get Account Called in Account Service");
                AccountDetails accountDetails;
                using (HttpClient _client = new HttpClient())
                {
                    StringValues token;
                    _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out token);
                    _client.BaseAddress = new Uri(_configuration["BaseUrl:Account"]);
                    _client.DefaultRequestHeaders.Add("Authorization", token.ToString());
                    HttpResponseMessage responseMessage = _client.GetAsync($"api/account/getAccount/{accountId}").Result;
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        accountDetails = JsonConvert.DeserializeObject<AccountDetails>(responseMessage.Content.ReadAsStringAsync().Result);
                        return accountDetails;
                    }
                    return null;
                }

            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                throw;
            }
        }


        public List<AccountDetails> GetAllAccounts()
        {
            try
            {
                _logger.Info("Get All Accounts Called in Account Service");
                List<AccountDetails> accountDetails = new List<AccountDetails>();
                using (HttpClient _client = new HttpClient())
                {
                    _client.BaseAddress = new Uri(_configuration["BaseUrl:Account"]);
                    HttpResponseMessage responseMessage = _client.GetAsync("api/account/getAllAccounts").Result;
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        accountDetails = JsonConvert.DeserializeObject<List<AccountDetails>>(responseMessage.Content.ReadAsStringAsync().Result);
                        return accountDetails;
                    }
                    return null;
                }

            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                throw;
            }

        }
    }
}
