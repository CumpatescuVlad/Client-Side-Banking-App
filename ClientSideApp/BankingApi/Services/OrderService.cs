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
        

        public OrderService(ILogger<OrderService> logger, IReadData readData,IModifyData modifyData)
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
                SenderBallance = orderModel.SenderBallance,

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


        public void ExecuteOrders()
        {
            _logger.LogInformation("Job Started");
            var ordersList = _readData.ReadOrders();

            foreach (var order in ordersList)
            {
                Thread.Sleep(5000);

                var transferModel = JsonConvert.DeserializeObject<TransferModel>(order.TransferModel);
                var accountInfo = _readData.ReadAccountInfo(order.CustomerName);

                if (accountInfo.Balance < transferModel.Amount)
                {
                    return;
                }

                try
                {
                    if (order.EndingDate == DateTime.Now.ToString("yyyy-MM-dd") || transferModel.SenderBallance < 50)
                    {
                        _logger.LogInformation($"Order finished for {order.CustomerName}");

                        continue;
                    }
                    _modifyData.UpdateBallance(transferModel);
                    Thread.Sleep(5000);
                    _modifyData.InsertTransaction(transferModel);
                    _logger.LogInformation($"Transfer Succesfull From {order.CustomerName} To {transferModel.CustomerName}");

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    _logger.LogInformation($"Transfer Not Completed From {order.CustomerName} To {transferModel.CustomerName}");

                }

            }

        }
    }
}
