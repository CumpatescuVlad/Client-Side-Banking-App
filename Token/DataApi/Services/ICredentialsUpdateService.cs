using DataApi.Modeles;
using System.Net;

namespace DataApi.Services
{
    public interface ICredentialsUpdateService
    {
        HttpStatusCode ChangePassword(CredentialsModel credentials);
        HttpStatusCode ChangePin(CredentialsModel credentials);
    }
}