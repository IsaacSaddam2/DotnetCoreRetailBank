using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RulesAPI.Models;
using RulesAPI.Repository;
using System;
using System.Collections.Generic;

namespace RulesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RulesController : ControllerBase
    {
        private readonly IRulesRepository _rulesRepository;
        private readonly ILog _logger = LogManager.GetLogger(typeof(RulesController));

        public RulesController(IRulesRepository rulesRepository)
        {
            _rulesRepository = rulesRepository;
        }

        [HttpGet("[action]/{AccountId:int}")]
        public IActionResult EvaluateMinBalance(int AccountId)
        {
            try
            {
                _logger.Info("Evaluating Minimum Balance in Rules Controller");
                if (AccountId == 0)
                    return BadRequest();
                RuleStatus ruleStatus = _rulesRepository.GetMinimumBalance(AccountId);
                if (ruleStatus == null)
                    return BadRequest();
                return Ok(ruleStatus);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        [HttpGet("[action]")]
        public IActionResult GetServiceCharges()
        {
            try
            {
                _logger.Info("Getting Service Charges in Rules Controller");
                List<ServiceChargeResponse> serviceChargeResponses = new List<ServiceChargeResponse>();
                serviceChargeResponses = _rulesRepository.GetServiceCharges();
                if (serviceChargeResponses == null)
                    return NoContent();
                return Ok(serviceChargeResponses);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
