﻿using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TransactionAPI.Models;
using TransactionAPI.Repository;

namespace TransactionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Customer")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ILog _logger = LogManager.GetLogger(typeof(TransactionController));

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }



        [HttpPost("[action]")]
        public IActionResult Deposit([FromBody] Account account)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new Ref_Transaction_Status { Trans_Status_Code = 3, Trans_Status_Description = Trans_Status_Description.Disputed });
                Ref_Transaction_Status ref_Transaction_Status = _transactionRepository.Deposit(account);
                return Ok(ref_Transaction_Status);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost("[action]")]
        public IActionResult WithDraw([FromBody] Account account)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new Ref_Transaction_Status { Trans_Status_Code = 3, Trans_Status_Description = Trans_Status_Description.Disputed });
                Ref_Transaction_Status ref_Transaction_Status = _transactionRepository.Withdraw(account);
                return Ok(ref_Transaction_Status);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost("[action]")]
        public IActionResult Transfer([FromBody] Transfer transfer)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new Ref_Transaction_Status { Trans_Status_Code = 3, Trans_Status_Description = Trans_Status_Description.Disputed });
                Ref_Transaction_Status ref_Transaction_Status = _transactionRepository.Transfer(transfer);
                return Ok(ref_Transaction_Status);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("[action]/{accountId}")]
        public IActionResult GetTransactions(int accountId)
        {
            try
            {
                List<Financial_Transaction> financial_Transactions = _transactionRepository.GetTransactions(accountId);
                if (financial_Transactions == null)
                    return NotFound();
                return Ok(financial_Transactions);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
