using DataApi.Modeles;
using DataApi.Services;
using Microsoft.AspNetCore.Mvc;

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
           
            return NotFound();
        }
    }
}
