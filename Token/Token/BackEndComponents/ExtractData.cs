using System.Data.SqlClient;

namespace Token.BackEndComponents
{
    public class ExtractData
    {
        private readonly SqlConnection connnection = new(Data.ConnectionString);

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
        public object ReadUserData(string customerName)
        {
            //object customerData = null;

            //var readPassword = new SqlCommand(Data.ReadCustomerTable(customerName), connnection);

            //connnection.Open();

            //var reader = readPassword.ExecuteReader();

            //while (reader.Read())
            //{
            //    customerData = new CustomerData()
            //    {
            //        //CustomerFullName = reader.GetString(0),
            //        //CustomerPassword = reader.GetString(1),
            //        //CustomerPhoneNumber = reader.GetString(2),
            //        //CustomerEmail = reader.GetString(3),
            //        //CustomerPIN =reader.GetString(4),

            //    };

            //}

            connnection.Close();
            reader.Close();
            readPassword.Dispose();

            return customerData;

        }
    }
}
