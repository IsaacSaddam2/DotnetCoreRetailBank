using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RulesAPI.Controllers;
using RulesAPI.Models;
using RulesAPI.Repository;
using RulesAPI.Utilities;
using System.Collections.Generic;

namespace NUnitRulesAPITest
{

    public class RulesTests
    {
        RulesRepository rulesRepository;
        Mock<IRulesRepository> rulesRepositoryMock;
        Mock<IAccountService> accountServiceMock;
        RulesController rulesController;


        [SetUp]
        public void Setup()
        {
            rulesRepositoryMock = new Mock<IRulesRepository>();
            accountServiceMock = new Mock<IAccountService>();
            rulesController = new RulesController(rulesRepositoryMock.Object);
            rulesRepository = new RulesRepository(accountServiceMock.Object);

        }


        [Test]
        [TestCase(1, 1400.50)]
        [TestCase(2, 2800.60)]
        [TestCase(3, 15000)]
        [TestCase(4, 150000.34)]
        public void EvaluateValidMinimumBalance(int id, double balance)
        {
            rulesRepositoryMock.Setup(x => x.GetMinimumBalance(It.IsAny<int>())).Returns(new RuleStatus { Status = Status.Allowed });
            accountServiceMock.Setup(c => c.GetAccount(It.IsAny<int>())).Returns(new AccountDetails { AccountId = id, Balance = balance });
            var result = rulesController.EvaluateMinBalance(id) as OkObjectResult;
            var model = result.Value as RuleStatus;
            Assert.AreEqual(Status.Allowed, model.Status);

        }


        [Test]
        [TestCase(1, 400)]
        [TestCase(2, 800.45)]
        [TestCase(3, 100)]
        [TestCase(4, 150.89)]
        public void EvaluateInValidMinimumBalance(int id, double balance)
        {
            rulesRepositoryMock.Setup(x => x.GetMinimumBalance(It.Is<int>(i => i < Charges.MinimumBalance))).Returns(new RuleStatus { Status = Status.Denied });
            accountServiceMock.Setup(c => c.GetAccount(It.IsAny<int>())).Returns(new AccountDetails { AccountId = 1, Balance = balance });
            var result = rulesController.EvaluateMinBalance(id) as OkObjectResult;
            var model = result.Value as RuleStatus;
            Assert.AreEqual(Status.Denied, model.Status);
        }

        [Test]
        [TestCase(0, 4100.90)]
        [TestCase(0, 1800.44)]
        [TestCase(0, 1100)]
        [TestCase(null, 1150)]
        public void CheckAccountId(int id, double balance)
        {
            rulesRepositoryMock.Setup(x => x.GetMinimumBalance(It.Is<int>(i => i > Charges.MinimumBalance))).Returns(new RuleStatus { Status = Status.Allowed });
            accountServiceMock.Setup(c => c.GetAccount(It.IsAny<int>())).Returns(new AccountDetails { AccountId = 1, Balance = balance });
            var result = rulesController.EvaluateMinBalance(id) as BadRequestResult;
            Assert.AreEqual(400, result.StatusCode);
        }


        [Test]
        [TestCase(101, 102)]
        [TestCase(2, 3)]
        [TestCase(31004, 31005)]
        [TestCase(2345, 2346)]
        public void GetServiceCharges(int id, int id2)
        {
            rulesRepositoryMock.Setup(x => x.GetServiceCharges()).Returns(new List<ServiceChargeResponse> {
                new ServiceChargeResponse{AccountId=id,WithdrawAmount=Charges.ServiceCharge},
                new ServiceChargeResponse{AccountId=id2,WithdrawAmount=Charges.ServiceCharge}
            });
            var result = rulesController.GetServiceCharges() as ObjectResult;
            var model = result.Value as List<ServiceChargeResponse>;
            foreach (var i in model)
            {
                Assert.AreEqual(200, i.WithdrawAmount);
            }
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(200, result.StatusCode);

        }


        [Test]
        public void GetServicecChargesEmpty()
        {
            List<ServiceChargeResponse> nullList = null;
            rulesRepositoryMock.Setup(x => x.GetServiceCharges()).Returns(nullList);
            var result = rulesController.GetServiceCharges() as NoContentResult;
            Assert.AreEqual(204, result.StatusCode);
        }


        [Test]
        [TestCase(1, 500, 2, 000.99)]
        [TestCase(3456, 900, 3457, 999.90)]
        [TestCase(4967, 500, 4968, 989.89)]
        public void GetAccountsLessThanMinimumBalance(int id, double balance, int id1, double balance2)
        {
            accountServiceMock.Setup(x => x.GetAllAccounts()).Returns(new List<AccountDetails> {
                new AccountDetails{AccountId=id,Balance=balance},
                new AccountDetails{AccountId=id1,Balance=balance2}
            });
            var result = rulesRepository.GetServiceCharges();
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(id, result[0].AccountId);
            Assert.AreEqual(id1, result[1].AccountId);
        }



        [Test]
        [TestCase(1, 1500.50, 2, 11100.00)]
        [TestCase(3456, 1900.20, 3457, 78999.48)]
        [TestCase(4967, 5500, 4968, 49989)]
        public void GetAccountsGreaterThanMinimumBalance(int id, double balance, int id1, double balance1)
        {
            accountServiceMock.Setup(x => x.GetAllAccounts()).Returns(new List<AccountDetails> {
                new AccountDetails{AccountId=id,Balance=balance},
                new AccountDetails{AccountId=id1,Balance=balance1}
            });
            var result = rulesRepository.GetServiceCharges();
            Assert.AreEqual(0, result.Count);

        }


        [Test]
        public void GetAccountsEmptyList()
        {
            List<AccountDetails> accountDetails = null;
            accountServiceMock.Setup(x => x.GetAllAccounts()).Returns(accountDetails);
            var result = rulesRepository.GetServiceCharges();
            Assert.AreEqual(null, result);

        }


    }
}
