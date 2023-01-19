using DataApi.Config;
using DataApi.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Net;

namespace DataApi.src
{
    public class CredentialsProvider : ICredentialsProvider
    {
        private readonly ConfigModel _config;
        private readonly ILogger<CredentialsProvider> _logger;

        public CredentialsProvider(IOptions<ConfigModel> config, ILogger<CredentialsProvider> logger)
        {
            _config = config.Value;
            _logger = logger;
        }

        public UserDTO ReadUserCredentials(string customerName)
        {
            var connection = new SqlConnection(_config.ConnectionString);

            var userData = new UserDTO();

            var readPassword = new SqlCommand(QuerryStrings.ReadCustomer(customerName), connection);

            try
            {
                connection.Open();

                var reader = readPassword.ExecuteReader();

                while (reader.Read())
                {
                    userData = new UserDTO()
                    {
                        CustomerFullName = reader.GetString(0),
                        CustomerPassword = reader.GetString(1),
                        CustomerPhoneNumber = reader.GetString(2),
                        CustomerEmail = reader.GetString(3),
                        CustomerPin = reader.GetString(4),
                    };

                }
                return userData;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return userData = new UserDTO() 
                {
                    CustomerFullName = null,
                    CustomerPassword = null,
                    CustomerPhoneNumber = null,
                    CustomerEmail = null,
                    CustomerPin = null,

                };
                
            }
            finally
            {
                connection.Close();
            }
           
        }

        public HttpStatusCode UpdateUserCredentials(string userName, string? password, string? pin)
        {
            var connection = new SqlConnection(_config.ConnectionString);
            var responseCode = HttpStatusCode.NotFound;

            connection.Open();

            if (password is null)
            {
                var updatePin = new SqlCommand(QuerryStrings.UpdateCredentials(userName, password, pin), connection);

                var adapter = new SqlDataAdapter();

                adapter.UpdateCommand = updatePin;

                adapter.UpdateCommand.ExecuteNonQuery();

                responseCode = HttpStatusCode.OK;

            }

            else if (pin is null)
            {
                var updatePassword = new SqlCommand(QuerryStrings.UpdateCredentials(userName, password, pin), connection);

                var adapter = new SqlDataAdapter();

                adapter.UpdateCommand = updatePassword;

                adapter.UpdateCommand.ExecuteNonQuery();

                responseCode = HttpStatusCode.OK;
            }

            connection.Close();

            return responseCode;
        }

    }
}
