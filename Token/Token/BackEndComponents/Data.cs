namespace Token.UnderTheHood
{
    public static class Data
    {
        private static string _connectionString =
           @"Server=tcp:vlad07072003.database.windows.net,1433;Initial Catalog=BankApp;Persist Security Info=False;
            User ID=Vlad;Password=Apicultor__69;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;
            Connection Timeout=30;";

        public static string ConnectionString { get => _connectionString; }

        public static string ReadInstallTime(string customerName) => $"Select FirstInstall from Customers Where CustomerFullName='{customerName}'";

        public static string ChangeFirstInstall(string customerName) => $"Update Customers set FirstInstall='{0}' where CustomerFullName='{customerName}' ";

        public static string ChangePIN(string customerName, string newPIN) => $"Update Customers set CustomerAppPin='{newPIN}' where CustomerFullName='{customerName}' ";

        public static string ReadPassword(string customerName) => $"Select CustomerFullName ,CustomerPassword , CustomerPhoneNumber , CustomerEmail from Customers Where CustomerFullName='{customerName}'";

        public static string ChangePassword(string customerName, string newPassword) => $"Update Customers set CustomerPassword='{newPassword}' where CustomerFullName='{customerName}' ";

        public static string SMSApi(string phoneNumber, string content) => $"https://platform.clickatell.com/messages/http/send?apiKey=fhlOJRDERgqU2bTDhyWM_Q==&to=4{phoneNumber}&content={content}";

    }
}
