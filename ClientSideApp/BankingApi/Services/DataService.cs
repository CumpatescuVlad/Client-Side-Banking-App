using BankingApi.DataAcces;
using Newtonsoft.Json;


namespace BankingApi.Services
{
    public class DataService : IDataService
    {
        private readonly IDataAcces _dataAcces;

        public DataService(IDataAcces dataAcces)
        {
            _dataAcces = dataAcces;
        }

        public string GetAccountInfo(string customerName)
        {
            return JsonConvert.SerializeObject(_dataAcces.ReadAccountInfo(customerName));
        }

        public string GetAccountTransactions(string customerName,string accountNumber) 
        {
            return JsonConvert.SerializeObject(_dataAcces.ReadAccountTransactions(customerName,accountNumber));
        }


    }
}
