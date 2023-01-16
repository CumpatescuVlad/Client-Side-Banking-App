using DataApi.Modeles;
namespace DataApi.src
{
    public static class QuerryStrings
    {
        public static string ReadCustomer(string customerName) => $"Select CustomerFullName ,CustomerPassword , CustomerPhoneNumber , CustomerEmail ,CustomerPin From Customer Where CustomerFullName='{customerName}'";

        public static string UpdateCredentials(CredentialsModel credentials)
        {
            string querry ="";

            if (credentials.Password is null)
            {
                querry = $"Update Customer Set CustomerPin='{credentials.Pin}' Where CustomerFullName='{credentials.UserName}'";
            }
            else if(credentials.Pin is null)
            {
                querry = $"Update Customer Set CustomerPassword='{credentials.Password}' Where CustomerFullName='{credentials.UserName}'";
            }
            
            return querry;
        }
    }
}
