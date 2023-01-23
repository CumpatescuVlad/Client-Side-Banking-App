namespace BankingApi.Services
{
    public interface IInfoService
    {
        string GetAccountInfo(string customerName);
        string GetCompaniesNames();


    }
}