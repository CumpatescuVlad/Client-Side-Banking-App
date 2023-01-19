using DataApi.DTOs;
using DataApi.src;
using Newtonsoft.Json;

namespace DataApi.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly ICredentialsProvider _credentials;

        public AuthentificationService(ICredentialsProvider credentials)
        {
            _credentials = credentials;
        }

        public bool LoginSuccesfully(string customerName, string password)
        {
            UserDTO userDTO = _credentials.ReadUserCredentials(customerName);

            return password == userDTO.CustomerPassword;
        }

        public string ReturnUserData(string customerName)
        {
            return JsonConvert.SerializeObject(_credentials.ReadUserCredentials(customerName));

        }
    }
}
