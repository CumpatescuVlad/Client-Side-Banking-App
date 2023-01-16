using DataApi.Modeles;
using DataApi.Services;
using DataApi.src;
using Microsoft.AspNetCore.Http;
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

        [Route("api/ChangeUserPin")]

        public IActionResult Pin(CredentialsModel credentials)
        {
            if (_credentialsUpdateService.ChangePin(credentials) is HttpStatusCode.OK)
            {
                return Ok();
            }
            else if (_credentialsUpdateService.ChangePassword(credentials) is HttpStatusCode.OK)
            {
                return Ok();
            }
           
            return NotFound();
        }
    }
}
