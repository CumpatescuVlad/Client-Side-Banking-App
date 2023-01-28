using BankingApi.Models;
using System.Net;

namespace BankingApi.DataAcces
{
    public interface IModifyData
    {
        HttpStatusCode InsertTransaction(TransactionModel transactionModel);
        HttpStatusCode UpdateBallance(TransferModel transferModel);
        HttpStatusCode InsertNewOrder(OrderModel orderModel,string transferModel);
    }
}