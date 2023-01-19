using DataApi.DTOs;
using System.Net;

namespace DataApi.src
{
    public interface ICredentialsProvider
    {
        UserDTO ReadUserCredentials(string customerName);
        HttpStatusCode UpdateUserCredentials(string userName, string? password, string? pin);
    }
}