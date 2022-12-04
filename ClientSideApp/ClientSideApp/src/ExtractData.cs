using Microsoft.Data.SqlClient;

namespace ClientSideApp
{
    public class ExtractData
    {
        private readonly SqlConnection connection = new(DataSelection.ConnectionString);
        private readonly SqlConnection secondConnection = new(DataSelection.ConnectionString);

        public string ReadCustomerTransactions(string customerName)
        {
            string transactions = null;

            var transactionCommand = new SqlCommand(DataSelection.SelectData(@"CustomerName,CustomerAccountNo,CustomerIBAN,
            CustomerAccountName,Amount,Date,TransactionType", "TransactionsTable", "CustomerName", customerName), connection);

            connection.Open();

            var readTransactions = transactionCommand.ExecuteReader();

            while (readTransactions.Read())
            {
                transactions += $"You {readTransactions.GetValue(6)} {readTransactions.GetInt32(4)} LEI on {readTransactions.GetString(5)} -- {readTransactions.GetString(3)} account\n";

            }
            readTransactions.Close();

            var readAppTransactionsCommand = new SqlCommand(DataSelection.
                SelectData("Amount,Date,TransactionType,IBAN", "AppTransactions", "CustomerName", customerName), connection);

            var reader = readAppTransactionsCommand.ExecuteReader();

            while (reader.Read())
            {
                transactions += $"You {reader.GetString(2)} to {ReadReciverName(reader.GetString(3))} {reader.GetInt32(0)} LEI on {reader.GetString(1)}\n";

            }
            reader.Close();

            readTransactions.Close();
            connection.Close();
            transactionCommand.Dispose();

            return transactions;
        }

        public string ReadReciverName(string IBAN)
        {
            string customerName = null;
            var reaReciverNameCommand = new SqlCommand(DataSelection.SelectData("CustomerName", "Accounts", "AccountIBAN", IBAN), secondConnection);
            secondConnection.Open();
            var reader = reaReciverNameCommand.ExecuteReader();

            while (reader.Read())
            {
                customerName = reader.GetString(0);
            }
            reader.Close();
            secondConnection.Close();
            return customerName;
        }
        public string ReadAccountData(string customerName)
        {
            object accountData = null;
            string accountInfo = null;
            var readAccountDataCommand =
                new SqlCommand(DataSelection.
                SelectData("AccountIBAN,AccountNumber,Amount,AccountName", "Accounts", "CustomerName", customerName), connection);

            connection.Open();

            var reader = readAccountDataCommand.ExecuteReader();

            while (reader.Read())
            {
                accountData = new AccountData() 
                {
                    AccountIBAN= reader.GetString(0),
                    AccountNumber= reader.GetString(1),
                    Balance = reader.GetInt32(2),
                    AccountName= reader.GetString(3),

                };

                Temp.CreateFile("AccountData.json",JsonConversion.SearializeData(accountData));

                accountInfo = $"Current Account {reader.GetString(3)} {reader.GetInt32(2)} RON.";

            }
            connection.Close();
            readAccountDataCommand.Dispose();
            return accountInfo;
        }

        public void ReadCompanyAccounts(ComboBox comboBox, ComboBox secondCombo)
        {
            var readCompanyAccounts =
                new SqlCommand(DataSelection
                .SelectClause("CompanyName,CompanyServices,CompanyIBAN", "CompaniesAccounts"), secondConnection);

            secondConnection.Open();

            var reader = readCompanyAccounts.ExecuteReader();

            while (reader.Read())
            {
                comboBox.Items.Add($"{reader.GetString(0)}\n");
                secondCombo.Items.Add($"{reader.GetString(2)}\n");
            }
            reader.Close();

            secondConnection.Close();
        }
        public string ReadCreditCard(string customerName)
        {
            string creditCardData = null;

            var readCreditCardDataCommand = new SqlCommand(DataSelection.SelectData("CustomerName,CreditCardNumber", "CreditCard", "CustomerName", customerName), connection);

            connection.Open();

            var reader = readCreditCardDataCommand.ExecuteReader();

            while (reader.Read())
            {
                creditCardData = $"{reader.GetValue(0)} \n{reader.GetValue(1)}";
            }
            connection.Close();

            return creditCardData;
        }

    }
}
