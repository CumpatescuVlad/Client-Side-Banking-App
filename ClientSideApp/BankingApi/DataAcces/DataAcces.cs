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
        private readonly ILogger<DataAcces> _logger;

        public DataAcces(IOptions<ConfigurationModel> configModel, ILogger<DataAcces> logger)
        {
            _configModel = configModel.Value;
            _logger = logger;
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

        public TransactionsDTO ReadAccountTransactions(string customerName, string accountIBAN, string status)
        {
            var transactions = new TransactionsDTO();

            var _connection = new SqlConnection(_configModel.ConnectionString);
            var transactionCommand = new SqlCommand(QuerryStrings.SelectAccountTransactions(customerName, accountIBAN, status), _connection);
            _connection.Open();
            if (status == "Income")
            {


                var reader = transactionCommand.ExecuteReader();

                while (reader.Read())
                {
                    transactions = new TransactionsDTO()
                    {
                        CustomerFullName = reader.GetString(0),
                        TypeOfTransaction = reader.GetString(1),
                        AccountUsed = reader.GetString(2),
                        Amount = reader.GetInt32(3),
                        Recipient = "Current Account",
                        TransactionDate = reader.GetString(4),

                    };

                }

            }

            else if (status == "Outcome")
            {
                var reader = transactionCommand.ExecuteReader();

                while (reader.Read())
                {
                    transactions = new TransactionsDTO()
                    {
                        CustomerFullName = "Current Account",
                        TypeOfTransaction = reader.GetString(0),
                        AccountUsed = reader.GetString(1),
                        Amount = reader.GetInt32(2),
                        Recipient = reader.GetString(3),
                        TransactionDate = reader.GetString(4),

                    };

                }

            }
            _connection.Close();
            return transactions;
        }
        public HttpStatusCode UpdateBallance(TransferModel transferModel)
        {
            var _connection = new SqlConnection(_configModel.ConnectionString);
            var updateSenderBallance = new SqlCommand(QuerryStrings.UpdateAccountBallance(transferModel.CustomerName, transferModel.Amount, "Sender"), _connection);
            var updateRecipientBallance = new SqlCommand(QuerryStrings.UpdateAccountBallance(transferModel.Recipient, transferModel.Amount, "Recipient"), _connection);
            try
            {
                _connection.Open();

                var senderAdapter = new SqlDataAdapter()
                {
                    UpdateCommand = updateSenderBallance,
                };

                var recipientAdapter = new SqlDataAdapter()
                {
                    UpdateCommand = updateRecipientBallance,
                };

                senderAdapter.UpdateCommand.ExecuteNonQuery();
                recipientAdapter.UpdateCommand.ExecuteNonQuery();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message);
                return HttpStatusCode.InternalServerError;
            }
            finally
            {
                _connection.Close();
            }

        }


        public HttpStatusCode InsertTransaction(TransferModel transferModel)
        {
            var _connection = new SqlConnection(_configModel.ConnectionString);
            var insertTransactionCommand = new SqlCommand(QuerryStrings.InsertTransaction(transferModel), _connection);
            try
            {
                _connection.Open();

                var adapter = new SqlDataAdapter()
                {
                    UpdateCommand = insertTransactionCommand,
                };

                adapter.UpdateCommand.ExecuteNonQuery();

                return HttpStatusCode.OK;

            }
            catch (Exception ex)
            {
                //log ex.MEssage in logger

                return HttpStatusCode.InternalServerError;

            }
            finally
            {
                _connection.Close();
            }

        }

        public CompanyDTO ReadCompanyNames()
        {
            var companyNames = new CompanyDTO(null,null,null);
            string name = null;
            string service = null;
            string IBAN = null;
            var connection = new SqlConnection(_configModel.ConnectionString);
            var readCompaniesCommand = new SqlCommand(QuerryStrings.SelectCompanies(),connection);

            connection.Open();

            var reader = readCompaniesCommand.ExecuteReader();

            while (reader.Read())
            {
                name += reader.GetString(0)+"\n";
                service += reader.GetString(1)+"\n";
                IBAN += reader.GetString(2) + "\n";

                companyNames = new CompanyDTO(name, service, IBAN);

                //companyNames = new CompanyDTO()
                //{
                //    CompanyName =reader.GetString(0) ,
                //    CompanyService= reader.GetString(1),
                //    CompanyIBAN= reader.GetString(2),
                    
                //};

            }
            connection.Close();

            return companyNames;

        }

    }
}
