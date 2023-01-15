using DataApi.Config;
using DataApi.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace DataApi.src
{
    public class Credentials : ICredentials
    {
        private readonly ConfigModel _config;

        public Credentials(IOptions<ConfigModel> config)
        {
            _config = config.Value;
        }

        public UserDTO ReadUserCredentials(string customerName)
        {
            var connection = new SqlConnection(_config.ConnectionString);

            var userData = new UserDTO();

            var readPassword = new SqlCommand(QuerryStrings.ReadCustomer(customerName), connection);

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
            connection.Close();

            return userData;

        }

    }
}
