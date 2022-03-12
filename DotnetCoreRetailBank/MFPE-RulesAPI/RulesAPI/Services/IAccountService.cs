using RulesAPI.Models;
using System.Collections.Generic;

namespace RulesAPI.Repository
{
    public interface IAccountService
    {
        AccountDetails GetAccount(int accountId);
        List<AccountDetails> GetAllAccounts();
    }
}