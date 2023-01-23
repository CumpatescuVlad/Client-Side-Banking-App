using BankingApi.DataAcces;
using BankingApi.Models;
using Newtonsoft.Json;
using System.Net;

namespace BankingApi.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IDataAcces _dataAcces;
        public TransactionService(IDataAcces dataAcces)
        {
            _dataAcces = dataAcces;
        }
        public HttpStatusCode NewTransfer(TransferModel transferModel)
        {
            if (transferModel.Amount>transferModel.SenderBallance)
            {
                return HttpStatusCode.BadRequest;
            }
           
            return _dataAcces.UpdateBallance(transferModel);
        }

        public HttpStatusCode RegisterTransaction(TransferModel transferModel)
        {
            return _dataAcces.InsertTransaction(transferModel);
        }

        public string GetIncomeTransactions(string customerName, string accountIBAN)
        {
            return JsonConvert.SerializeObject(_dataAcces.ReadAccountTransactions(customerName, accountIBAN, "Income"));
        }

        public string GetOutcomeTransactions(string customerName, string accountIBAN)
        {
            return JsonConvert.SerializeObject(_dataAcces.ReadAccountTransactions(customerName, accountIBAN, "Outcome"));
        }
    }
}
