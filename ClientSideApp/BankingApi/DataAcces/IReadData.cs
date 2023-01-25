using BankingApi.DTO;

namespace BankingApi.DataAcces
{
    public interface IReadData
    {
        AccountDataDTO ReadAccountInfo(string customerName);
        TransactionsDTO ReadAccountTransactions(string customerName, string status);
        string ReadStatementTransactions(string customerName, string status);
        CompanyDTO ReadCompanyNames();
    }
}