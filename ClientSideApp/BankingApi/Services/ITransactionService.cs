using BankingApi.Models;
using System.Net;

namespace BankingApi.Services
{
    public interface ITransactionService
    {
        HttpStatusCode NewTransfer(TransferModel transferModel);
        HttpStatusCode RegisterTransaction(TransferModel transferModel);
        string GetIncomeTransactions(string customerName, string accountIBAN);
        string GetOutcomeTransactions(string customerName, string accountIBAN);
    }
}