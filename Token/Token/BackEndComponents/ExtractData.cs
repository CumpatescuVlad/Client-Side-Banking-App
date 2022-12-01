using Microsoft.Data.SqlClient;

namespace Token.UnderTheHood
{
    public class ExtractData
    {
        private readonly SqlConnection connnection = new SqlConnection(Data.ConnectionString);

        public bool isFirstInstall(string customerName)
        {
            bool isFirstInstall = false;

            var readInstallTimeCommand = new SqlCommand(Data.ReadInstallTime(customerName), connnection);

            connnection.Open();

            var reader = readInstallTimeCommand.ExecuteReader();

            while (reader.Read())
            {
                isFirstInstall = Convert.ToBoolean(reader.GetInt32(0));

            }

            connnection.Close();

            reader.Close();

            readInstallTimeCommand.Dispose();

            return isFirstInstall;
        }
        public void ReadPassword(string customerName)
        {
            var readPassword = new SqlCommand(Data.ReadPassword(customerName), connnection);

            connnection.Open();

            var reader = readPassword.ExecuteReader();

            while (reader.Read())
            {
                Temp.CreateFile("CustomerFullName.txt", $"{reader.GetValue(0)}");
                Temp.CreateFile("CustomerPassword.txt", $"{reader.GetValue(1)}");
                Temp.CreateFile("CustomerPhoneNumber.txt", $"{reader.GetValue(2)}");
                Temp.CreateFile("CustomerEmail.txt", $"{reader.GetValue(3)}");
               
            }

            connnection.Close();

            reader.Close();
            readPassword.Dispose();
        }
    }
}
