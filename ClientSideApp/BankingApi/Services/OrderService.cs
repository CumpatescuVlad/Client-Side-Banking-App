using BankingApi.DataAcces;
using BankingApi.Models;
using Newtonsoft.Json;
using System.Net;

namespace BankingApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IReadData _readData;
        private readonly IModifyData _modifyData;


        public OrderService(ILogger<OrderService> logger, IReadData readData, IModifyData modifyData)
        {
            _logger = logger;
            _readData = readData;
            _modifyData = modifyData;
        }

        public HttpStatusCode CreateOrder(OrderModel orderModel)
        {
            var transferModel = new TransferModel()
            {
                CustomerName = orderModel.CustomerName,
                TypeOfTransaction = orderModel.TypeOfTransaction,
                AccountIBAN = orderModel.AccountIBAN,
                Amount = orderModel.Amount,
                Recipient = orderModel.Recipient,

            };
            string serializedModel = JsonConvert.SerializeObject(transferModel);

            if (_modifyData.InsertNewOrder(orderModel, serializedModel) is HttpStatusCode.Created)
            {
                return HttpStatusCode.Created;
            }
            else
            {
                return HttpStatusCode.InternalServerError;
            }

        }

    }
}
