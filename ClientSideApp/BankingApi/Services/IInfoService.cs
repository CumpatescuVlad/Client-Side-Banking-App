using BankingApi.Models;

namespace BankingApi.Services
{
    public interface IInfoService
    {
        string GetAccountInfo(string customerName);
        string GetCompaniesNames();
        byte[] GetWordStatement(StatementModel statementModel);
        byte[] GetPdfStatement(StatementModel statementModel);

    }
}