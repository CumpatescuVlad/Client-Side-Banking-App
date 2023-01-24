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
        private readonly IInfoService _infoService;

        public FunctionsController(IInfoService infoService)
        {
            _infoService= infoService;
        }

        [HttpGet]

        [Route("Functions/Companies/GetCompanies")]

        [ServiceFilter(typeof(ModelValidation))]

        public IActionResult GetCompanies()
        {
            var companiesInfo = _infoService.GetCompaniesNames();

            if (companiesInfo is null)
            {
                return NotFound();

            }
            return Ok(companiesInfo);
        }

        [HttpPost]

        [Route("Functions/BillPayment")]

        [ServiceFilter(typeof(ModelValidation))]

        public IActionResult PayBill(TransferModel transferModel)
        {


            return BadRequest();
        }

        
    }
}
