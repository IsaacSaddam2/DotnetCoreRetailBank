using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBankingProject.Models
{
    public class CustomerAccountViewModel
    {
        public Customer Customer { get; set; }
        public List<Account> AccountDetails { get; set; }
    }
}
