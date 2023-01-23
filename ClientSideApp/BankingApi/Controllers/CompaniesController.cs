using BankingApi.Filters;
using BankingApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApi.Controllers
{
    
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IInfoService _infoService;

        public CompaniesController(IInfoService infoService)
        {
            _infoService= infoService;
        }

        [HttpGet]

        [Route("Companies/GetCompanies")]

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
    }
}
