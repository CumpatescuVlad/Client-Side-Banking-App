using BankingApi.Filters;
using BankingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingApi.Controllers
{

    [ApiController]
    public class AccountInfoController : ControllerBase
    {
        private readonly IDataService _dataService;

        public AccountInfoController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]

        [Route("/api/GetAccount/{customerName}")]

        [ServiceFilter(typeof(ModelValidation))]

        public IActionResult AccountInfo(string customerName)
        {
            var accountInfo = _dataService.GetAccountInfo(customerName);

            if (accountInfo is not null)
            {
                return Ok(accountInfo);
            }

            return NotFound("Customer Name Could Not Be Found");
        }

    }
}
