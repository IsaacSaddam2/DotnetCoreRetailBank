using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using RetailBankingProject.Controllers;

namespace NUnitTestsForMVC
{
    [TestFixture]
    public class EmployeeControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreateCustomerView()
        {

            var obj = new EmployeeController();

            var actResult = obj.ViewCustomers() as IActionResult;

           
        }

    }
    }
