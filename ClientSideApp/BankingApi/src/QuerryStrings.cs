using BankingApi.Models;

namespace BankingApi.src
{
    public static class QuerryStrings
    {
        public static string InsertTransaction(TransactionModel transactionModel) => $"Insert Into Transactions (CustomerFullName,TypeOfTransaction,AccountUsed,Amount,Recipient,TransactionDate) Values ('{transactionModel.CustomerName}','{transactionModel.TypeOfTransaction}','{transactionModel.AccountIBAN}','{transactionModel.Amount}','{transactionModel.Recipient}','{DateTime.UtcNow}')";
        public static string InsertOrder(OrderModel orderModel, string transferModel) => $"Insert Into Orders (CustomerFullName,TypeOfOrder,AmountToRemain,StartingDate,EndingDate,TransferModel) Values ('{orderModel.CustomerName}','{orderModel.TypeOfOrder}','{orderModel.AmountToRemain}','{orderModel.StartingDate}','{orderModel.EndingDate}','{transferModel}')";
        public static string SelectAccountData(string customerName) => $"Select CustomerFullName,AccountNumber,AccountIBAN,Ballance From Accounts Where CustomerFullName='{customerName}'";
        public static string SelectCompanies() => "Select CompanyName,CompanyService,CompanyIBAN From Companies";
        public static string SelectOrders() => "Select CustomerFullName,TypeOfOrder,AmountToRemain,StartingDate,EndingDate,TransferModel From Orders";

        public static string SelectAccountTransactions(string customerName, string status)
        {
            string querryString;
            if (status == "Income")
            {
                querryString = $"Select CustomerFullName,TypeOfTransaction,AccountUsed,Amount,TransactionDate From Transactions Where Recipient='{customerName}'";

            }

            else
            {
                querryString = $"Select TypeOfTransaction,AccountUsed,Amount,Recipient,TransactionDate From Transactions Where CustomerFullName='{customerName}'";
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
            else if (customerStatus == "Recipient")
            {
                updateQuerry = $"Update Accounts set Ballance = (Select Ballance From Accounts Where CustomerFullName='{customerName}')+'{ballance}' Where CustomerFullName='{customerName}'";
            }
            else
            {
                updateQuerry = $"Update Companies set CompanyBallance=(Select CompanyBallance From Companies  Where CompanyName ='{customerName}')+'{ballance}' Where CompanyName='{customerName}'";
            }

            return updateQuerry;
        }




    }
}
