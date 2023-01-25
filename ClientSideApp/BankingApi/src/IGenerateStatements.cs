using BankingApi.Models;
using System.Net;

namespace BankingApi.src
{
    public interface IGenerateStatements
    {
        HttpStatusCode GeneratePdfStatement(StatementModel statementModel, string incomeTransactions, string outcomeTransactions);
        HttpStatusCode GenerateWordStatement(StatementModel statementModel, string incomeTransactions, string outcomeTransactions);
    }
}