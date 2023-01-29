using BankingApi.Models;
using System.Net;

namespace BankingApi.Services
{
    public interface IOrderService
    {
        HttpStatusCode CreateOrder(OrderModel orderModel);

    }
}