using TransactionAPI.Models;

namespace TransactionAPI.Services
{
    public interface IRulesService
    {
        RuleStatus CheckMinimumBalance(Account account);
    }
}