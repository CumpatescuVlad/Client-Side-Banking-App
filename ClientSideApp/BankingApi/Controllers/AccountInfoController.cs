using BankingApi.Filters;
using BankingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingApi.Controllers
{

    [ApiController]
    public class AccountInfoController : ControllerBase
    {
        private readonly IInfoService _infoService;

        public AccountInfoController(IInfoService infoService)
        {
            _infoService = infoService;
        }

        [HttpGet]

        [Route("/Account/GetInfo/{customerName}")]

        [ServiceFilter(typeof(ModelValidation))]

        public IActionResult AccountInfo(string customerName)
        {
            var accountInfo = _infoService.GetAccountInfo(customerName);

            if (accountInfo is null)
            {
                return NotFound("Customer Name Could Not Be Found");
            }

            return Ok(accountInfo);
        }

    }
}
