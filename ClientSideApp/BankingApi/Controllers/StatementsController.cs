using BankingApi.Filters;
using BankingApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApi.Controllers
{
   
    [ApiController]
    public class StatementsController : ControllerBase
    {
        [HttpPost]

        [Route("api/GenerateStatement")]

        [ServiceFilter(typeof(ModelValidation))]

        public IActionResult Generatestatement(ModelBase model)
        {
            //GenerateWordStatemnt();
            //GenerateCsvStatemnt();
            //GenrateCsvStatement();

            return NoContent();
        }
    }
}
