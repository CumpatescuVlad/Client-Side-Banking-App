using DataApi.Modeles;
using DataApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DataApi.Controllers
{

    [ApiController]
    public class ActivationController : ControllerBase
    {
        private readonly IActivationService _activationService;

        public ActivationController(IActivationService activationService)
        {
            _activationService = activationService;
        }

        [HttpPost]

        [Route("api/EmailActivation")]

        public IActionResult EmailActivation(EmailModel emailModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_activationService.EmailSentSuccesfully(emailModel))
            {
                return Ok();
            }

            else if (!_activationService.EmailSentSuccesfully(emailModel))
            {
                return StatusCode(500);
            }

            return NotFound();
        }


        [HttpPost]

        [Route("api/SmsActivation")]

        public IActionResult SmsActivation(SmsModel smsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_activationService.SmsSentSuccesfully(smsModel))
            {
                return Ok();
            }

            else if (!_activationService.SmsSentSuccesfully(smsModel))
            {
                return StatusCode(500);
            }

            return NotFound();
        }
    }
}
