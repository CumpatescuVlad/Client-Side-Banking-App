using BankingApi.Config;
using BankingApi.DTO;
using BankingApi.Models;
using BankingApi.src;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Net;

namespace BankingApi.DataAcces
{
    public class DataAcces : IDataAcces
    {

        private readonly ConfigurationModel _configModel;

        public DataAcces(IOptions<ConfigurationModel> configModel)
        {
            _configModel = configModel.Value;
        }

        public AccountDataDTO ReadAccountInfo(string customerName)
        {
            var accountData = new AccountDataDTO();
            var _connection = new SqlConnection(_configModel.ConnectionString);
            var accountCommand = new SqlCommand(QuerryStrings.SelectAccountData(customerName), _connection);
            _connection.Open();
            var reader = accountCommand.ExecuteReader();

            reader.Read();
            accountData = new AccountDataDTO()
            {
                CustomerName = reader.GetString(0),
                AccountNumber = reader.GetString(1),
                AccountIBAN = reader.GetString(2),
                Balance = reader.GetInt32(3),

            };
            reader.Close();

            _connection.Close();
            return accountData;
        }

        public TransactionsDTO ReadAccountTransactions(string customerName,string accountNumber)
        {
            var transactions = new TransactionsDTO();

            var _connection = new SqlConnection(_configModel.ConnectionString);
            var transactionCommand = new SqlCommand(QuerryStrings.SelectAccountTransactions(customerName,accountNumber), _connection);
            _connection.Open();
            var reader = transactionCommand.ExecuteReader();

            while (reader.Read())
            {
                transactions = new TransactionsDTO()
                {
                    TypeOfTransaction = reader.GetString(0),
                    AccountUsed = reader.GetString(1),
                    Amount = reader.GetInt32(2),
                    Recipient = reader.GetString(3),
                    TransactionDate = reader.GetString(4),

                };

            }
            _connection.Close();
            return transactions;
        }
        public HttpStatusCode UpdateBallance(TransferModel transferModel)
        {
            var _connection = new SqlConnection(_configModel.ConnectionString);
            var updateSenderBallance = new SqlCommand(QuerryStrings.UpdateAccountBallance(transferModel.Sender, transferModel.SenderBallance), _connection);
            var updateReciverBallance = new SqlCommand(QuerryStrings.UpdateAccountBallance(transferModel.Recipient, transferModel.RecipientBallance), _connection);
            try
            {
                _connection.Open();

                var senderAdapter = new SqlDataAdapter(updateSenderBallance);
                var reciverAdapter = new SqlDataAdapter(updateReciverBallance);

                senderAdapter.UpdateCommand.ExecuteNonQuery();
                reciverAdapter.UpdateCommand.ExecuteNonQuery();
                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                //log here ex.Message
                return HttpStatusCode.InternalServerError;
            }
            finally
            {
                _connection.Close();
            }

        }

        public void InsertTransaction(TransferModel transferModel)
        {

        }

       
    }
}
