namespace DataApi.src
{
    public static class QuerryStrings
    {
        public static string ReadCustomer(string customerName) => $"Select CustomerFullName ,CustomerPassword , CustomerPhoneNumber , CustomerEmail ,CustomerPin From Customer Where CustomerFullName='{customerName}'";

        public static string UpdateCredentials(string userName, string? password, string? pin)
        {
            string querry = "";

            if (password is null)
            {
                querry = $"Update Customer Set CustomerPin='{pin}' Where CustomerFullName='{userName}'";
            }
            else if (pin is null)
            {
                querry = $"Update Customer Set CustomerPassword='{password}' Where CustomerFullName='{userName}'";
            }

            return querry;
        }
    }
}
