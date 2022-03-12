using RulesAPI.Models;
using System.Collections.Generic;

namespace RulesAPI.Repository
{
    public interface IRulesRepository
    {
        RuleStatus GetMinimumBalance(int accountId);
        List<ServiceChargeResponse> GetServiceCharges();
    }
}