using DataApi.Modeles;
using DataApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DataApi.Controllers
{

    [ApiController]
    public class CredentialsController : ControllerBase
    {
        private readonly ICredentialsUpdateService _credentialsUpdateService;

        public CredentialsController(ICredentialsUpdateService credentialsUpdateService)
        {
            _credentialsUpdateService = credentialsUpdateService;
        }

        [HttpPut]

        [Route("api/ChangeUserCredentials")]

        public IActionResult Credentials(CredentialsModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_credentialsUpdateService.ChangePin(credentials.CustomerName, null, credentials.Pin) is HttpStatusCode.OK)
            {
                return Ok();
            }
            else if (_credentialsUpdateService.ChangePassword(credentials.CustomerName, credentials.Password, null) is HttpStatusCode.OK)
            {
                return Ok();
            }
            
            return NotFound();
        }
    }
}
