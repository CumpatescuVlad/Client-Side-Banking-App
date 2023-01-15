using DataApi.DTOs;

namespace DataApi.src
{
    public interface ICredentials
    {
        UserDTO ReadUserCredentials(string customerName);
    }
}