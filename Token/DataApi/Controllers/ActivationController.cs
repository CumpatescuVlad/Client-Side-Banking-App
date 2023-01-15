using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataApi.Services;
using DataApi.Modeles;

namespace DataApi.Controllers
{
    
    [ApiController]
    public class ActivationController : ControllerBase
    {
       private readonly IActivationService _activationService;

        public ActivationController(IActivationService activationService)
        {
            _activationService= activationService;
        }

        [HttpPost]

        [Route("api/EmailActivation")]

        public IActionResult EmailActivation(EmailModel emailModel)
        {
            if (_activationService.EmailSentSuccesfully(emailModel))
            {
                return Ok();
            }
            else if(emailModel == null) 
            {
                return BadRequest();
            }

            return NotFound();
        }
    }
}
