using DataApi.DTOs;
using DataApi.Modeles;
using System.Net;

namespace DataApi.src
{
    public interface ICredentials
    {
        UserDTO ReadUserCredentials(string customerName);

        HttpStatusCode UpdateUserCredentials(CredentialsModel credentials);
    }
}