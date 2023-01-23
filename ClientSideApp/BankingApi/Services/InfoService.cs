using BankingApi.DataAcces;
using Newtonsoft.Json;


namespace BankingApi.Services
{
    public class InfoService : IInfoService
    {
        private readonly IDataAcces _dataAcces;

        public InfoService(IDataAcces dataAcces)
        {
            _dataAcces = dataAcces;
        }

        public string GetAccountInfo(string customerName)
        {
            return JsonConvert.SerializeObject(_dataAcces.ReadAccountInfo(customerName));
        }

        public string GetCompaniesNames()
        {
            return JsonConvert.SerializeObject(_dataAcces.ReadCompanyNames());
        }
    }
}
