using DataApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataApi.Controllers
{

    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private readonly IAuthentificationService _authentification;

        public AuthentificationController(IAuthentificationService authentification)
        {
            _authentification = authentification;
        }

        [HttpGet]

        [Route("api/Login/{customerName}/{password}")]

        public IActionResult Login(string customerName, string password)
        {
            if (customerName is null||password is null)
            {
                return BadRequest();
            }

            if (_authentification.LoginSuccesfully(customerName, password))
            {
                return Content(_authentification.ReturnUserData(customerName));
            }

            else if (!_authentification.LoginSuccesfully(customerName, password))
            {
                return StatusCode(403);
            }

            return NotFound();
        }
    }
}
