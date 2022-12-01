using Microsoft.Data.SqlClient;

namespace ClientSideApp
{
    public class BallanceOperations
    {
        private readonly SqlConnection connection = new SqlConnection(DataSelection.ConnectionString);
        private readonly AccountData reciverAccountData = new();

        public void ExecuteTransfer(string colums, string table, string Keycolum, string IBAN, int amount)
        {
            int reciverAccountBallance = 0;
            connection.Open();

            var readReciverBallance = new SqlCommand(DataSelection.
                SelectData(colums, table, Keycolum, IBAN), connection);

            var reader = readReciverBallance.ExecuteReader();

            while (reader.Read())
            {
                reciverAccountBallance = reader.GetInt32(0);
            }
            reader.Close();

            var updateAmountCommand = new SqlCommand(DataSelection.UpdateAmount(table, reciverAccountBallance + amount, Keycolum, IBAN), connection);

            var updateAmount = new SqlDataAdapter(updateAmountCommand) { UpdateCommand = updateAmountCommand };

            updateAmount.UpdateCommand.ExecuteNonQuery();

            connection.Close();

            #region Object Disposing 
            updateAmount.Dispose();
            updateAmountCommand.Dispose();
            #endregion

        }

        public void UpdateSenderBallance(string table, int amount, int senderBallance, string keyColumn, string IBAN)
        {
            connection.Open();

            var updateBallance = new SqlCommand(DataSelection.UpdateAmount(table, senderBallance - amount, keyColumn, IBAN), connection);

            var adapter = new SqlDataAdapter() { UpdateCommand = updateBallance };

            adapter.UpdateCommand.ExecuteNonQuery();

            connection.Close();

        }

        public int ReadSenderAccountBalance(string colum, string table, string keycolum, string IBAN)
        {
            int senderAccountBallance = 0;

            connection.Open();

            var readCurrentBallance = new SqlCommand(DataSelection.
                SelectData(colum, table, keycolum, IBAN), connection);

            var reader = readCurrentBallance.ExecuteReader();

            while (reader.Read())
            {
                senderAccountBallance = reader.GetInt32(0);
            }

            connection.Close();

            return senderAccountBallance;
        }

        public void RegisterReciverTransaction(string IBAN, int amount, string senderIBAN)
        {

            var readReciverAccountData = new SqlCommand(DataSelection.
                SelectData("CustomerName,AccountIBAN,AccountNumber,AccountName", "Accounts", "AccountIBAN", IBAN), connection);

            connection.Open();

            var reader = readReciverAccountData.ExecuteReader();

            while (reader.Read())
            {
                reciverAccountData.CustomerName = reader.GetString(0);
                reciverAccountData.AccountIBAN = reader.GetString(1);
                reciverAccountData.AccountNumber = reader.GetString(2);
                reciverAccountData.AccountName = reader.GetString(3);

            }
            reader.Close();

            var insertReciverTransaction = new SqlCommand(DataSelection.
                InsertData("CustomerName,CustomerAccountNo,CustomerIBAN,CustomerAccountName,Amount,Date,TransactionType,IBAN", $"'{reciverAccountData.CustomerName}','{reciverAccountData.AccountNumber}','{reciverAccountData.AccountIBAN}','{reciverAccountData.AccountName}','{amount}','{DateTime.Now}','Recived','{senderIBAN}'"), connection);

            var adapter = new SqlDataAdapter() { InsertCommand = insertReciverTransaction };

            adapter.InsertCommand.ExecuteNonQuery();

            connection.Close();

        }

        public void RegisterSenderTransactions(string colums, string values)
        {
            var insertsenderTransaction = new SqlCommand(DataSelection.InsertData(colums, values), connection);

            connection.Open();

            var adapter = new SqlDataAdapter() { InsertCommand = insertsenderTransaction };

            adapter.InsertCommand.ExecuteNonQuery();

            connection.Close();

        }
    }
}
