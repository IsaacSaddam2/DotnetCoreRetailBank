﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RetailBankingClient.Models.Transaction;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RetailBankingProject.Services
{
    public class TransactionService : ITransactionService
    {

        private IHttpContextAccessor _httpContextAccessor;

        public TransactionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<HttpResponseMessage> Deposit(Account deposit)
        {
            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://localhost:5005");
                client.BaseAddress = new Uri("https://mfpe-transactionapi.azurewebsites.net");
                //Link Body Part{/api/Account/Deposit}
                string token = _httpContextAccessor.HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var stringPayload = JsonConvert.SerializeObject(deposit);
                var payload = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/Transaction/Deposit", payload);
                return response;
            }
        }

        public async Task<HttpResponseMessage> Withdraw(Account withdraw)
        {
            using (HttpClient client = new HttpClient())
            {
                string token = _httpContextAccessor.HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //client.BaseAddress = new Uri("http://localhost:5005");
                client.BaseAddress = new Uri("https://mfpe-transactionapi.azurewebsites.net");
                //Link Body Part{/api/Account/Withdraw}
                var payload = new StringContent(JsonConvert.SerializeObject(withdraw), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/Transaction/Withdraw", payload);
                return response;
            }
        }

        public async Task<HttpResponseMessage> Transfer(Transfer transfer)
        {
            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://localhost:5005");
                client.BaseAddress = new Uri("https://mfpe-transactionapi.azurewebsites.net");
                string token = _httpContextAccessor.HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var payload = new StringContent(JsonConvert.SerializeObject(transfer), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/Transaction/Transfer", payload);
                return response;
            }
        }

        public async Task<HttpResponseMessage> GetTransactions(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://localhost:5005");
                client.BaseAddress = new Uri("https://mfpe-transactionapi.azurewebsites.net");
                string token = _httpContextAccessor.HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync("api/Transaction/GetTransactions/" + id);
                return response;
            }
        }
    }

}
