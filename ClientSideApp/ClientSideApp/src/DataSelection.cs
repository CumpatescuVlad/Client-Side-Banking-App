namespace ClientSideApp
{
    public class DataSelection
    {
        private static string _connectionString =
            @"Server=tcp:vlad07072003.database.windows.net,1433;Initial Catalog=BankApp;Persist Security Info=False;
            User ID=Vlad;Password=Apicultor__69;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;
            Connection Timeout=30;";

        public static string ConnectionString { get => _connectionString; }

        public static string SelectClause(string columns, string table) => $"Select {columns} from {table}";

        public static string UpdateAmount(string table, int amount, string keyColum, string IBAN) => $"Update {table} set Amount ='{amount}' Where {keyColum} = '{IBAN}'";

        public static string InsertData(string colums, string values) => $"Insert into AppTransactions ({colums}) values ({values})";

        public static string SelectData(string columns, string table, string colum, string customerFullName) => $"Select {columns} from {table} where {colum}='{customerFullName}'";




    }
}
