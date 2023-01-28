using BankingApi.Services;
using Quartz;
using Quartz.Core;
namespace BankingApi.Jobs
{
    public class ResolveOrdersJob:IJob
    {
        private readonly IOrderService _orderService;
        public ResolveOrdersJob(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Task Execute(IJobExecutionContext jobContext)
        {
            _orderService.ExecuteOrders();

            return Task.CompletedTask;
        }

    }
}
