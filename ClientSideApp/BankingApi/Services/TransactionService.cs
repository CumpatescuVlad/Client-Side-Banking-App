using BankingApi.DataAcces;
using BankingApi.Models;
using Newtonsoft.Json;
using System.Net;

namespace BankingApi.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IModifyData _dataAcces;
        private readonly IReadData _readData;
        public TransactionService(IModifyData dataAcces, IReadData readData)
        {
            _dataAcces = dataAcces;
            _readData = readData;
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

        public string GetIncomeTransactions(string customerName)
        {
            return JsonConvert.SerializeObject(_readData.ReadAccountTransactions(customerName,"Income"));
        }

        public string GetOutcomeTransactions(string customerName)
        {
            return JsonConvert.SerializeObject(_readData.ReadAccountTransactions(customerName,"Outcome"));
        }

    }
}
