namespace DataApi.src
{
    public static class QuerryStrings
    {
        public static string ReadCustomer(string customerName) => $"Select CustomerFullName ,CustomerPassword , CustomerPhoneNumber , CustomerEmail ,CustomerPin From Customer Where CustomerFullName='{customerName}'";

    }
}
