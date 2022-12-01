using Microsoft.Data.SqlClient;

namespace ClientSideApp
{
    public class ExtractData
    {
        private readonly SqlConnection connection = new(DataSelection.ConnectionString);
        private readonly SqlConnection secondConnection = new(DataSelection.ConnectionString);

        public string ReadCustomerAccounts(string customerName)
        {
            string accountData = null;

            var readAccountCommand = new SqlCommand(DataSelection.SelectData("AccountName,Amount", "Accounts", "CustomerName", customerName), connection);

            connection.Open();

            var readAccountData = readAccountCommand.ExecuteReader();

            while (readAccountData.Read())
            {
                accountData = $"Current Account:\n {readAccountData.GetValue(0)} availabble cash: {readAccountData.GetValue(1)}";


            }
            connection.Close();
            readAccountCommand.Dispose();
            readAccountData.Close();
            return accountData;
        }

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
        public void ReadAccountData(string customerName)
        {
            var readAccountDataCommand =
                new SqlCommand(DataSelection.
                SelectData("CustomerName,AccountIBAN,AccountNumber,Amount,AccountName", "Accounts", "CustomerName", customerName), connection);

            connection.Open();

            var reader = readAccountDataCommand.ExecuteReader();

            while (reader.Read())
            {
                object acccountData = new AccountData()
                {
                    CustomerName = reader.GetString(0),
                    AccountIBAN = reader.GetString(1),
                    AccountNumber = reader.GetString(2),
                    Balance = reader.GetInt32(3),
                    AccountName = reader.GetString(4),

                };

                Temp.CreateFile("AccountData.json", JsonConversion.SearializeData(acccountData));

            }
            connection.Close();


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

        public string ReadCustomerPIN(string PIN)
        {
            string customerPIN = null;
            var readPIN = new SqlCommand(DataSelection.SelectData("CustomerAppPin", "Customers", "CustomerAppPin", PIN), connection);

            connection.Open();

            var reader = readPIN.ExecuteReader();

            while (reader.Read())
            {
                customerPIN = reader.GetString(0);
            }

            connection.Close();

            return customerPIN;
        }

    }
}
