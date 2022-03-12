using AuthenticationAPI.Controllers;
using AuthenticationAPI.Models;
using AuthenticationAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace AuthenticationAPI.Tests
{
    public class AuthenticationControllerTests
    {
        private Mock<ILoginRepository> _mockLogin;

        [SetUp]
        public void Intialize()
        {
            _mockLogin = new Mock<ILoginRepository>();
        }

        [Test]
        public void Login_ValidUser_UserResponse()
        {
            _mockLogin.Setup(c => c.Login(It.IsAny<UserRequest>())).Returns(new UserResponse { Id = 1, Token = "Token Generated", Message = "Login Successfully" });
            var controller = new AuthenticationController(_mockLogin.Object);
            var result = controller.Login(new UserRequest { Email = "vrajshah363@gmail.com", Password = "Vraj1234" }) as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);

        }

        [Test]
        public void Login_InValidUser_UserResponse()
        {
            _mockLogin.Setup(c => c.Login(It.IsAny<UserRequest>())).Returns(new UserResponse { Message = "Login Successfully" });
            var controller = new AuthenticationController(_mockLogin.Object);
            var result = controller.Login(new UserRequest { Email = "vrajshah363@gmail.com", Password = "Vraj1234" }) as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);

        }
    }
}
