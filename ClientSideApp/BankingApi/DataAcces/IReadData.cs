using BankingApi.DTO;

namespace BankingApi.DataAcces
{
    public interface IReadData
    {
        AccountDataDTO ReadAccountInfo(string customerName);
        TransactionsDTO ReadAccountTransactions(string customerName, string accountIBAN, string status);
        CompanyDTO ReadCompanyNames();
    }
}