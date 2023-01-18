using System.Net;

namespace DataApi.Services
{
    public interface ICredentialsUpdateService
    {
        HttpStatusCode ChangePassword(string userName, string password, string pin);
        HttpStatusCode ChangePin(string userName, string? password, string? pin);
    }
}