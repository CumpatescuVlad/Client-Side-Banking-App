namespace DataApi.Services
{
    public interface IAuthentificationService
    {
        bool LoginSuccesfully(string customerName, string password);
        string ReturnUserData(string customerName);
    }
}