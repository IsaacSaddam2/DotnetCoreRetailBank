using log4net;
using RulesAPI.Models;
using RulesAPI.Utilities;
using System;
using System.Collections.Generic;

namespace RulesAPI.Repository
{
    public class RulesRepository : IRulesRepository
    {
        private readonly IAccountService _accountService;
        private readonly ILog _logger = LogManager.GetLogger(typeof(RulesRepository));

        public RulesRepository(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public RuleStatus GetMinimumBalance(int accountId)
        {
            try
            {
                _logger.Info("Get Minimum Balance Called in Rules Repository");
                AccountDetails account = _accountService.GetAccount(accountId);
                if (account == null)
                    return new RuleStatus { Status = Status.Denied };
                if (account.Balance < Charges.MinimumBalance)
                    return new RuleStatus { Status = Status.Denied };
                return new RuleStatus { Status = Status.Allowed };
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                throw;
            }
        }

        public List<ServiceChargeResponse> GetServiceCharges()
        {
            try
            {
                _logger.Info("Getting Service Charges in Rules Repository");
                List<ServiceChargeResponse> result = new List<ServiceChargeResponse>();
                List<AccountDetails> accountDetails = _accountService.GetAllAccounts();
                if (accountDetails == null)
                    return null;
                foreach (AccountDetails item in accountDetails)
                {
                    if (item.Balance < Charges.MinimumBalance)
                        result.Add(new ServiceChargeResponse { AccountId = item.AccountId, WithdrawAmount = Charges.ServiceCharge });
                }
                return result;
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                throw;
            }

        }
    }
}
