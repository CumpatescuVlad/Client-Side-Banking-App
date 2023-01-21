namespace BankingApi.Services
{
    public interface IDataService
    {
        string GetAccountInfo(string customerName);
        string GetAccountTransactions(string customerName, string accountNumber);
    }
}