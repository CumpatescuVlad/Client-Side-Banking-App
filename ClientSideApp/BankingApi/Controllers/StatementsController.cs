using BankingApi.Filters;
using BankingApi.Models;
using BankingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingApi.Controllers
{

    [ApiController]
    public class StatementsController : ControllerBase
    {
        private readonly IInfoService _infoService;

        public StatementsController(IInfoService infoService)
        {
            _infoService = infoService;
        }

        [HttpPost]

        [Route("Statements/GenerateWordStatement")]

        [ServiceFilter(typeof(ModelValidation))]

        public IActionResult GenerateWordStatement(StatementModel statementModel)
        {
            var wordStatement = _infoService.GetWordStatement(statementModel);

            if (wordStatement is not null)
            {
                return File(wordStatement, "word/doc", "Statement.doc");
            }
            else if (wordStatement is null)
            {
                return StatusCode(500);
            }

            return NotFound();
        }

        [HttpPost]

        [Route("Statements/GeneratePdfStatement")]

        [ServiceFilter(typeof(ModelValidation))]

        public IActionResult Generatestatement(StatementModel statementModel)
        {
            var pdfStatement = _infoService.GetPdfStatement(statementModel);

            if (pdfStatement is not null)
            {
                return File(pdfStatement, "application/pdf", "Statement.pdf");

            }

            else if (pdfStatement is null)
            {
                return StatusCode(500);
            }

            return NotFound();
        }
    }
}
