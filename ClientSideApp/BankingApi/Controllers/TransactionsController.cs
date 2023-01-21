using BankingApi.Filters;
using BankingApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApi.Controllers
{
    
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IDataService _dataService;

        public TransactionsController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]

        [Route("/api/GetTransactions/{customerName}/{accountNumber}")]

        [ServiceFilter(typeof(ModelValidation))]

        public IActionResult GetTransactions(string customerName,string accountNumber)
        {
            var transactions = _dataService.GetAccountTransactions(customerName,accountNumber);

            if (transactions is null)
            {
                return NotFound("No Transactions Were Found");
                
            }

            return Ok(transactions);
        }

        [HttpPost]

        [Route("api/Transfer")]

        [ServiceFilter(typeof(ModelValidation))]

        public IActionResult NewTransfer()
        {

        }
    }
}
