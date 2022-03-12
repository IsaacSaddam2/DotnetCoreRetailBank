using EmployeeAPI.Models;
using System.Collections.Generic;

namespace EmployeeAPI.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployee();
        EmployeeResponse GetEmployee(Employee employee);
    }
}