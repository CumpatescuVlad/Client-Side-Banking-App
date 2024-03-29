﻿using BankingApi.Filters;
using BankingApi.Models;
using BankingApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BankingApi.Controllers
{
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]

        [Route("Account/NewTransfer")]

        [ServiceFilter(typeof(ModelValidation))]

        public IActionResult Transfer(TransferModel transferModel)
        {
            if (_transactionService.NewTransfer(transferModel) is HttpStatusCode.OK)
            {
                var registerTransaction = _transactionService.RegisterTransaction(transferModel);

                return StatusCode(Convert.ToInt32(registerTransaction));
            }

            else
            {
                return StatusCode(Convert.ToInt32(_transactionService.NewTransfer(transferModel)));
            }

        }


        [HttpGet]

        [Route("/Account/GetIncomeTransactions/{customerName}/{accountIBAN}")]

        [ServiceFilter(typeof(ModelValidation))]

        public IActionResult IncomeTransactions(string customerName)
        {
            var incomeTransactions = _transactionService.GetIncomeTransactions(customerName);

            if (incomeTransactions is null)
            {
                return NotFound("No Transactions Were Found");

            }

            return Ok(incomeTransactions);
        }

        [HttpGet]

        [Route("/Account/GetOutcomeTransactions/{customerName}/{accountIBAN}")]

        [ServiceFilter(typeof(ModelValidation))]

        public IActionResult OutcomeTransactions(string customerName)
        {
            var outcomeTransactions = _transactionService.GetOutcomeTransactions(customerName);

            if (outcomeTransactions is null)
            {
                return NotFound("No Transactions Were Found");

            }

            return Ok(outcomeTransactions);
        }

    }
}
