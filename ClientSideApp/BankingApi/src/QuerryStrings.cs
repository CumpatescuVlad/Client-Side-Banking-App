using BankingApi.Models;

namespace BankingApi.src
{
    public static class QuerryStrings
    {
        public static string SelectAccountData(string customerName) => $"Select CustomerFullName,AccountNumber,AccountIBAN,Ballance From Accounts Where CustomerFullName='{customerName}'";
        public static string SelectCompanies() => $"Select CompanyName,CompanyService,CompanyIBAN From Companies";
        //public static string SelectAccountTransactions(string customerName, string accountIBAN) => $"Select TypeOfTransaction,AccountUsed,Amount,Recipient,TransactionDate From Transactions Where CustomerFullName='{customerName}' AND AccountUsed='{accountIBAN}'";
        public static string SelectAccountTransactions(string customerName, string accountIBAN, string status)
        {
            string querryString;
            if (status == "Income")
            {
                querryString = $"Select CustomerFullName,TypeOfTransaction,AccountUsed,Amount,TransactionDate From Transactions Where Recipient='{customerName}'";
    
            }

            else
            {
                querryString = $"Select TypeOfTransaction,AccountUsed,Amount,Recipient,TransactionDate From Transactions Where CustomerFullName='{customerName}' AND AccountUsed='{accountIBAN}'";
            }

            return querryString;
        }
        public static string UpdateAccountBallance(string? customerName, int? ballance, string customerStatus)
        {
            string? updateQuerry;

            if (customerStatus == "Sender")
            {
                updateQuerry = $"Update Accounts set Ballance = (Select Ballance From Accounts Where CustomerFullName='{customerName}')-'{ballance}' Where CustomerFullName='{customerName}'";
            }
            else
            {
                updateQuerry = $"Update Accounts set Ballance = (Select Ballance From Accounts Where CustomerFullName='{customerName}')+'{ballance}' Where CustomerFullName='{customerName}'";
            }

            return updateQuerry;
        }

        public static string InsertTransaction(TransferModel transferModel)=> $"Insert Into Transactions (CustomerFullName,TypeOfTransaction,AccountUsed,Amount,Recipient,TransactionDate) Values ('{transferModel.CustomerName}','{transferModel.TypeOfTransaction}','{transferModel.AccountIBAN}','{transferModel.Amount}','{transferModel.Recipient}','{transferModel.DateAndTime}')";

        // public static string InsertTransaction(string customerName,TransferModel transferModel) => $"Insert Into Transactions (CustomerName,TypeOfTransaction,AccountUsed,Amount,Recipient,TransactionDate) Values ('{customerName}','{transferModel.}')";

    }
}
