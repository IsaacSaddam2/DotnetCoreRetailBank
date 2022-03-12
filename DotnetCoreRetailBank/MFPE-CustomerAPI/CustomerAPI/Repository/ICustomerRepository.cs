using CustomerAPI.Models;
using System.Collections.Generic;

namespace CustomerAPI.Repository
{
    public interface ICustomerRepository
    {
        CustomerCreationStatus CreateCustomer(Customer customer);
        Customer GetCustomerDetails(int customerId);
        CustomerResponse GetCustomer(CustomerRequest customerRequest);
        List<Customer> GetAllCustomers();
    }
}
