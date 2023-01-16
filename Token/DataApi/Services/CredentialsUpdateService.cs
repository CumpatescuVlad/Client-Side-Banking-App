using DataApi.src;
using DataApi.Modeles;
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

        public HttpStatusCode ChangePassword(CredentialsModel credentials)
        {
            var statusCode = HttpStatusCode.NotModified;
            if (_credentials.UpdateUserCredentials(credentials) is HttpStatusCode.OK)
            {
                statusCode = HttpStatusCode.OK;
            }

            return statusCode;
        }

        public HttpStatusCode ChangePin(CredentialsModel credentials)
        {
            var statusCode = HttpStatusCode.NotModified;

            if (_credentials.UpdateUserCredentials(credentials) is HttpStatusCode.OK)
            {
                statusCode = HttpStatusCode.OK;
            }

            return statusCode;
        }

    }
}
