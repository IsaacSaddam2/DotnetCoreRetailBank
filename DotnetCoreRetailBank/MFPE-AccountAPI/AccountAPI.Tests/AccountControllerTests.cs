﻿using AccountAPI.Controllers;
using AccountAPI.Models;
using AccountAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace AccountAPI.Tests
{
    [TestFixture]
    class AccountControllerTests
    {
        [Test]
        [TestCase(1)]
        public void GetCustomerAccounts_WhenCalledWithProperId_ReturnListOfAccounts(int id)
        {
            var mock = new Mock<IAccountRepository>();
            mock.Setup(x => x.GetCustomerAccounts(id)).Returns(new List<Account> {
                new Account{AccountId=1,Balance=0,CustomerId=id,AccountType=AccountType.Current},
                new Account{AccountId=2,Balance=0,CustomerId=id,AccountType=AccountType.Saving}
            });
            var controller = new AccountController(mock.Object);
            var result = controller.GetCustomerAccounts(id) as ObjectResult;
            Assert.AreEqual(result.StatusCode, 200);
            Assert.IsNotNull(result.Value);
            var model = result.Value as List<Account>;//List<Account>;
            Assert.AreEqual(2, model.Count);
        }
        [Test]
        [TestCase(1)]

        public void GetCustomerAccounts_WhenIdIsNotValid_ReturnMessage(int id)
        {
            var mock = new Mock<IAccountRepository>();
            mock.Setup(x => x.GetCustomerAccounts(id)).Returns((List<Account>)null);

            string s = "No Account Found for this Customer";

            var controller = new AccountController(mock.Object);
            var result = controller.GetCustomerAccounts(id) as ObjectResult;
            Assert.AreEqual(s, result.Value);
            Assert.AreEqual(404, result.StatusCode);

        }
        [Test]
        [TestCase(1)]
        public void GetAccount_WhenCalledWithProperId_ReturnObjectOfAccount(int id)
        {
            var mock = new Mock<IAccountRepository>();
            mock.Setup(x => x.GetAccount(id))
                      .Returns(new Account { AccountId = 1, Balance = 0, CustomerId = id, AccountType = AccountType.Current });
            var controller = new AccountController(mock.Object);
            var result = controller.GetAccount(id) as ObjectResult;
            Assert.AreEqual(result.StatusCode, 200);
            Assert.IsNotNull(result.Value);
            var model = result.Value as Account;//List<Account>;
            Assert.AreEqual(1, model.AccountId);
        }
        [Test]
        [TestCase(1)]
        public void GetAccount_WhenIdIsNotValid_ReturnMessage(int id)
        {
            var mock = new Mock<IAccountRepository>();
            mock.Setup(x => x.GetAccount(id)).Returns((Account)null);
            var controller = new AccountController(mock.Object);
            var result = controller.GetAccount(id) as ObjectResult;
            string s = "No Account Found for this Account Id";
            Assert.AreEqual(result.StatusCode, 404);
            //Assert.IsNotNull(result.Value);
            // var model = result.Value as Account;//List<Account>;
            Assert.AreEqual(s, result.Value);
        }

        [Test]
        [TestCase(1, "14/01/1999", "15/01/1999")]
        public void GetStatements_WhenCalled_ReturnStatement(int accountId, string from_date, string to_date)
        {
            var mock = new Mock<IAccountRepository>();
            mock.Setup(x => x.GetStatements(accountId, from_date, to_date)).Returns(new List<Statement> {
                new Statement { Id=1,AccountId=1 },
                new Statement { Id=2,AccountId=1 }
            });
            var controller = new AccountController(mock.Object);
            var result = controller.GetStatement(accountId, from_date, to_date) as ObjectResult;
            Assert.AreEqual(result.StatusCode, 200);
            Assert.IsNotNull(result.Value);
            var model = result.Value as List<Statement>;//List<Account>;
            Assert.AreEqual(2, model.Count);
        }

        [Test]
        [TestCase(1, "14/01/1999", "15/01/1999")]
        public void GetStatements_WhenCalledWithInvalidId_ReturnNoStatementMessage(int accountId, string from_date, string to_date)
        {
            var mock = new Mock<IAccountRepository>();
            mock.Setup(x => x.GetStatements(accountId, from_date, to_date)).Returns((List<Statement>)null);
            var controller = new AccountController(mock.Object);
            var result = controller.GetStatement(accountId, from_date, to_date) as ObjectResult;
            string s = "No Statements";
            Assert.AreEqual(result.StatusCode, 404);

            // var model = result.Value as List<Statement>;//List<Account>;
            Assert.AreEqual(s, result.Value);
        }



        [Test]

        public void Deposit_WhenCalledWithProperAmount_ReturnTrue()
        {

            var mock = new Mock<IAccountRepository>();
            AmountRequest ar = new AmountRequest { AccountId = 1, Amount = 1000, Narration = "DimaagaKharaabHaiMera" };
            mock.Setup(x => x.Deposit(ar)).Returns(true);
            var controller = new AccountController(mock.Object);
            var result = controller.Deposit(ar);
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<OkResult>());

            //var okResult = result as OkObjectResult;

            //Assert.AreEqual(200, okResult.StatusCode);
            //Assert.IsNotNull(okResult);

        }
        [Test]
        public void Withdraw_WhenCalledWithProperAmount_ReturnTrue()
        {

            var mock = new Mock<IAccountRepository>();
            AmountRequest ar = new AmountRequest { AccountId = 1, Amount = 1000, Narration = "DimaagaKharaabHaiMera" };
            mock.Setup(x => x.Withdraw(ar)).Returns(true);
            var controller = new AccountController(mock.Object);
            var result = controller.Withdraw(ar);
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<OkResult>());

            //var okResult = result as OkObjectResult;

            //Assert.AreEqual(200, okResult.StatusCode);
            //Assert.IsNotNull(okResult);

        }


    }
}
