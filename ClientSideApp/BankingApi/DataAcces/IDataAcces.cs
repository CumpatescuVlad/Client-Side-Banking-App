using BankingApi.DTO;
using BankingApi.Models;
using System.Net;

namespace BankingApi.DataAcces
{
    public interface IDataAcces
    {
        AccountDataDTO ReadAccountInfo(string customerName);
        TransactionsDTO ReadAccountTransactions(string customerName,string accountNumber);
        void InsertTransaction(TransferModel transferModel);
        HttpStatusCode UpdateBallance(TransferModel transferModel);
    }
}