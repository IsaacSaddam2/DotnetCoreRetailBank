using EmployeeAPI.Models;
using EmployeeAPI.Models.Data;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeRepository));

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        public List<Employee> GetAllEmployee()
        {
            try
            {
                _logger.Info("Getting All Employee");
                List<Employee> employees = _context.Employees.ToList();
                return employees;
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                throw;
            }

        }
        public EmployeeResponse GetEmployee(Employee employee)
        {
            try
            {
                _logger.Info("Getting Employee");
                Employee employee1 = _context.Employees.Where(c => c.Email == employee.Email && c.Password == employee.Password).SingleOrDefault();
                if (employee1 == null)
                    return null;
                return new EmployeeResponse { Id = employee1.Id };
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                throw;
            }

        }
    }
}
