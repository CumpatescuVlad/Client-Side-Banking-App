using BankingApi.DataAcces;
using Newtonsoft.Json;


namespace BankingApi.Services
{
    public class InfoService : IInfoService
    {
        private readonly IReadData _readData;

        public InfoService(IReadData readData)
        {
            _readData = readData;
        }

        public string GetAccountInfo(string customerName)
        {
            return JsonConvert.SerializeObject(_readData.ReadAccountInfo(customerName));
        }

        public string GetCompaniesNames()
        {
            return JsonConvert.SerializeObject(_readData.ReadCompanyNames());
        }
    }
}
