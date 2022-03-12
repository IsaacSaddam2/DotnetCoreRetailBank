using System.Collections.Generic;
using TransactionAPI.Models;

namespace TransactionAPI.Repository
{
    public interface ITransactionRepository
    {
        Ref_Transaction_Status Deposit(Account account);
        List<Financial_Transaction> GetTransactions(int accountId);
        Ref_Transaction_Status Transfer(Transfer transfer);
        Ref_Transaction_Status Withdraw(Account account);
    }
}