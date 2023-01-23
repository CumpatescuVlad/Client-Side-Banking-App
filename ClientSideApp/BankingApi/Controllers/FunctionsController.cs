using BankingApi.Filters;
using BankingApi.Models;
using BankingApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BankingApi.Controllers
{
    
    [ApiController]
    public class FunctionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public FunctionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

       
    }
}
