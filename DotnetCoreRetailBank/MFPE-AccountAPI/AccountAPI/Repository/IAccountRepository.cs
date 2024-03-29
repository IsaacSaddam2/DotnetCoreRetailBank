﻿using AccountAPI.Models;
using System.Collections.Generic;

namespace AccountAPI.Repository
{
    public interface IAccountRepository
    {
        bool CreateAccount(int customerId);
        bool Deposit(AmountRequest amountRequest);
        Account GetAccount(int accountId);
        List<Account> GetCustomerAccounts(int customerId);
        List<Statement> GetStatements(int accountId, string from_date, string to_date);
        bool Withdraw(AmountRequest amountRequest);
    }
}