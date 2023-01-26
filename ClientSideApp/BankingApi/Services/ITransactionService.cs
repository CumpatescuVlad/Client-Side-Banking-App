using BankingApi.Models;
using System.Net;

namespace BankingApi.Services
{
    public interface ITransactionService
    {
        HttpStatusCode NewTransfer(TransferModel transferModel);
        HttpStatusCode RegisterTransaction(TransactionModel transactionModel);
        string GetIncomeTransactions(string customerName);
        string GetOutcomeTransactions(string customerName);
    }
}