using System.Net;

namespace DataApi.Services
{
    public class CredentialsUpdateService : ICredentialsUpdateService
    {
        private readonly src.ICredentials _credentials;

        public CredentialsUpdateService(src.ICredentials credentials)
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
