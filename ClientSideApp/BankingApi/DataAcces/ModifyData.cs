using BankingApi.Config;
using BankingApi.Models;
using BankingApi.src;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Net;

namespace BankingApi.DataAcces
{
    public class ModifyData : IModifyData
    {

        private readonly ConfigurationModel _configModel;
        private readonly ILogger<ModifyData> _logger;

        public ModifyData(IOptions<ConfigurationModel> configModel, ILogger<ModifyData> logger)
        {
            _configModel = configModel.Value;
            _logger = logger;
        }


        public HttpStatusCode UpdateBallance(TransferModel transferModel)
        {
            var _connection = new SqlConnection(_configModel.ConnectionString);
            var updateSenderBallance = new SqlCommand(QuerryStrings.UpdateAccountBallance(transferModel.CustomerName, transferModel.Amount, "Sender"), _connection);
            var updateRecipientBallance = new SqlCommand(QuerryStrings.UpdateAccountBallance(transferModel.Recipient, transferModel.Amount, "Recipient"), _connection);
            if (transferModel.TypeOfTransaction == "Bill Payment")
            {
                updateRecipientBallance = new SqlCommand(QuerryStrings.UpdateAccountBallance(transferModel.Recipient, transferModel.Amount, "Bill Payment"), _connection);
            }

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

                return HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return HttpStatusCode.InternalServerError;
            }
            finally
            {
                _connection.Close();
            }

        }


        public HttpStatusCode InsertTransaction(TransactionModel transactionModel)
        {
            var _connection = new SqlConnection(_configModel.ConnectionString);
            var insertTransactionCommand = new SqlCommand(QuerryStrings.InsertTransaction(transactionModel), _connection);
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
                _logger.LogError(ex.Message);

                return HttpStatusCode.InternalServerError;

            }
            finally
            {
                _connection.Close();
            }

        }

        public HttpStatusCode InsertNewOrder(OrderModel orderModel, string transferModel)
        {
            var connection = new SqlConnection(_configModel.ConnectionString);
            var insertNewOrderCommand = new SqlCommand(QuerryStrings.InsertOrder(orderModel, transferModel), connection);

            try
            {
                connection.Open();
                var adapter = new SqlDataAdapter() { InsertCommand = insertNewOrderCommand };
                adapter.InsertCommand.ExecuteNonQuery();
                return HttpStatusCode.Created;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return HttpStatusCode.InternalServerError;

            }


        }


    }
}
