using BankingApi.Models;

namespace BankingApi.src
{
    public static class QuerryStrings
    {
        public static string SelectAccountData(string customerName) => $"Select CustomerFullName,AccountNumber,AccountIBAN,Ballance From Accounts Where CustomerFullName='{customerName}'";
        public static string SelectAccountTransactions(string customerName,string accountNumber) => $"Select TypeOfTransaction,AccountUsed,Amount,Recipient,TransactionDate From Transactions Where CustomerFullName='{customerName}' AND AccountUsed='{accountNumber}'";
        public static string UpdateAccountBallance(string? customerName,int? ballance) =>$"Update Accounts set Ballance= Ballance+'{ballance}' Where CustomerFullName='{customerName}'";
       // public static string InsertTransaction(string customerName,TransferModel transferModel) => $"Insert Into Transactions (CustomerName,TypeOfTransaction,AccountUsed,Amount,Recipient,TransactionDate) Values ('{customerName}','{transferModel.}')";

    }
}
