namespace Token.BackEndComponents
{
    public static class Data
    {
        private static string _connectionString =
           @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Bank;
           UserID =Vlad;Password =Apicultor__69;Integrated Security=True;
           Connect Timeout=30;Encrypt=False; TrustServerCertificate=False;
           ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static string ConnectionString { get => _connectionString; }

        public static string ReadInstallTime(string customerName) => $"Select FirstInstall from Customers Where CustomerFullName='{customerName}'";

        public static string ChangeFirstInstall(string customerName) => $"Update Customers set FirstInstall='{0}' where CustomerFullName='{customerName}' ";

        public static string ChangePIN(string customerName, string newPIN) => $"Update Customers set CustomerAppPin='{newPIN}' where CustomerFullName='{customerName}' ";

        // public static string ReadCustomerTable(string customerName) => $"Select CustomerFullName ,CustomerPassword , CustomerPhoneNumber , CustomerEmail ,CustomerAppPin from Customers Where CustomerFullName='{customerName}'";

        public static string ChangePassword(string customerName, string newPassword) => $"Update Customers set CustomerPassword='{newPassword}' where CustomerFullName='{customerName}' ";

        public static string SMSApi(string phoneNumber, string content) => $"https://platform.clickatell.com/messages/http/send?apiKey=fhlOJRDERgqU2bTDhyWM_Q==&to=4{phoneNumber}&content={content}";

    }
}
