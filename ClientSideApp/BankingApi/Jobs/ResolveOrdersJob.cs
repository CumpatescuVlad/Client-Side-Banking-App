using BankingApi.DataAcces;
using BankingApi.Models;
using Newtonsoft.Json;
using Quartz;
namespace BankingApi.Jobs
{
    public class ResolveOrdersJob : IJob
    {

        private readonly ILogger<ResolveOrdersJob> _logger;
        private readonly IReadData _readData;
        private readonly IModifyData _modifyData;
        public ResolveOrdersJob(ILogger<ResolveOrdersJob> logger, IReadData readData, IModifyData modifyData)
        {
            _logger = logger;
            _readData = readData;
            _modifyData = modifyData;
        }

        public Task Execute(IJobExecutionContext jobContext)
        {
            _logger.LogInformation("Job Started");
            var ordersList = _readData.ReadOrders();

            foreach (var order in ordersList)
            {
                Thread.Sleep(5000);

                var transferModel = JsonConvert.DeserializeObject<TransferModel>(order.TransferModel);
                var accountInfo = _readData.ReadAccountInfo(order.CustomerName);

                try
                {
                    if (order.EndingDate == DateTime.Now.ToString("yyyy-MM-dd"))
                    {
                        _logger.LogWarning($"Order finished for {order.CustomerName}");

                        continue;
                    }
                    else if (accountInfo.Balance < transferModel.Amount || accountInfo.Balance <= order.AmountToRemain)
                    {
                        _logger.LogWarning($"Not enough funds for user {order.CustomerName}");

                        continue;
                    }
                    _modifyData.UpdateBallance(transferModel);
                    Thread.Sleep(5000);
                    _modifyData.InsertTransaction(transferModel);
                    _logger.LogInformation($"Transfer Succesfull From {order.CustomerName} To {transferModel.Recipient}");

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    _logger.LogWarning($"Transfer Not Completed From {order.CustomerName} To {transferModel.CustomerName}");


                }
            }
            return Task.CompletedTask;
        }

    }
}
