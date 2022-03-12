using EmployeeAPI.Models;
using EmployeeAPI.Repository;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeController));

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Employee")]
        public IActionResult GetAllEmployees()
        {
            List<Employee> employees = _employeeRepository.GetAllEmployee();
            if (employees == null)
                return NotFound();
            return Ok(employees);
        }

        [HttpPost("[action]")]
        public IActionResult CheckCredentials([FromBody] Employee employee)
        {
            try
            {
                _logger.Info("Check Employee Credentials");
                if (!ModelState.IsValid)
                    return BadRequest();
                EmployeeResponse employee1 = _employeeRepository.GetEmployee(employee);
                if (employee1 == null)
                    return BadRequest(employee1);
                return Ok(employee1);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
