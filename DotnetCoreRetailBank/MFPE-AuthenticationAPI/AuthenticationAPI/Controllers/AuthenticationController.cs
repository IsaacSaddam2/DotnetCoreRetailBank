using AuthenticationAPI.Models;
using AuthenticationAPI.Repository;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(AuthenticationController));
        private readonly ILoginRepository _loginRepository;

        public AuthenticationController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        [HttpPost("[action]")]
        public IActionResult Login([FromBody] UserRequest userRequest)
        {
            try
            {
                _logger.Info("Login Method called in Authentication Controller");
                UserResponse response = _loginRepository.Login(userRequest);
                if (response.Id != 0)
                    return Ok(response);
                return BadRequest(response);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Try Again After Some Time");
            }
        }
    }
}
