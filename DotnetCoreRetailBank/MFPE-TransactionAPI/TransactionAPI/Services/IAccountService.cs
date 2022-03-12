using TransactionAPI.Models;

namespace TransactionAPI.Services
{
    public interface IAccountService
    {
        AmountResponse Deposit(Account account);
        bool GetAccountId(int accountId);
        AmountResponse WithDraw(Account account);
    }
}