using BankingApi.Filters;
using BankingApi.Models;
using BankingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingApi.Controllers
{

    [ApiController]
    public class FunctionsController : ControllerBase
    {
        private readonly IInfoService _infoService;
        private readonly IOrderService _orderService;

        public FunctionsController(IInfoService infoService,IOrderService orderService)
        {
            _infoService = infoService;
            _orderService = orderService;
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

        [Route("Functions/Orders")]

        [ServiceFilter(typeof(ModelValidation))]

        public IActionResult Orders(OrderModel orderModel)
        {
            if (_orderService.CreateOrder(orderModel) is System.Net.HttpStatusCode.Created)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }


    }
}
