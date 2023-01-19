using System.Net;
using DataApi.src;

namespace DataApi.Services
{
    public class CredentialsUpdateService : ICredentialsUpdateService
    {
        private readonly ICredentialsProvider _credentials;

        public CredentialsUpdateService(ICredentialsProvider credentials)
        {
            _credentials = credentials;
        }

        public HttpStatusCode ChangePassword(string userName, string? password, string? pin)
        {
            var statusCode = HttpStatusCode.NotModified;
            if (_credentials.UpdateUserCredentials(userName, password, pin) is HttpStatusCode.OK)
            {
                statusCode = HttpStatusCode.OK;
            }

            return statusCode;
        }

        public HttpStatusCode ChangePin(string userName, string? password, string? pin)
        {
            var statusCode = HttpStatusCode.NotModified;

            if (_credentials.UpdateUserCredentials(userName, password, pin) is HttpStatusCode.OK)
            {
                statusCode = HttpStatusCode.OK;
            }

            return statusCode;
        }

    }
}
