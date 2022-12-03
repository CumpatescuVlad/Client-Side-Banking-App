using Newtonsoft.Json;
using System.Data.SqlClient;

namespace Token.BackEndComponents
{
    public class ChangeUserCredentials
    {
        private readonly SqlConnection connection = new(Data.ConnectionString);

        public void ChangePassword(string newPassword, Label succesMessage)
        {
            CustomerData customerData = JsonConvert.DeserializeObject<CustomerData>(Temp.ReadFile("CustomerData.json"));
            var updatePasswordCommand = new SqlCommand(Data.ChangePassword(customerData.CustomerFullName, newPassword), connection);
            var setFirstInstallToFalseCommand = new SqlCommand(Data.ChangeFirstInstall(customerData.CustomerFullName), connection);

            connection.Open();

            var passwordAdapter = new SqlDataAdapter { UpdateCommand = updatePasswordCommand };
            passwordAdapter.UpdateCommand.ExecuteNonQuery();


            var firstIntallAdapter = new SqlDataAdapter { UpdateCommand = setFirstInstallToFalseCommand };
            firstIntallAdapter.UpdateCommand.ExecuteNonQuery();

            succesMessage.Text = "Password Was Succesfully Changed!";

            connection.Close();

            #region ObjectDisposing
            passwordAdapter.Dispose();
            firstIntallAdapter.Dispose();
            updatePasswordCommand.Dispose();
            setFirstInstallToFalseCommand.Dispose();
            #endregion

        }
        public void ChangePIN(string newPin, Label succesLabel)
        {
            CustomerData customerData = JsonConvert.DeserializeObject<CustomerData>(Temp.ReadFile("CustomerData.json"));
            var changePINCommand = new SqlCommand(Data.ChangePIN(customerData.CustomerFullName, newPin), connection);
            var setFirstInstallToFalseCommand = new SqlCommand(Data.ChangeFirstInstall(customerData.CustomerFullName), connection);

            connection.Open();


            var pinAdapter = new SqlDataAdapter { UpdateCommand = changePINCommand };
            pinAdapter.UpdateCommand.ExecuteNonQuery();



            var firstInstallAdapter = new SqlDataAdapter { UpdateCommand = setFirstInstallToFalseCommand };
            firstInstallAdapter.UpdateCommand.ExecuteNonQuery();


            succesLabel.Text = "PIN Was Succesfully Changed!";

            connection.Close();

            #region ObjectDisposing
            pinAdapter.Dispose();
            changePINCommand.Dispose();
            firstInstallAdapter.Dispose();
            setFirstInstallToFalseCommand.Dispose();
            #endregion


        }
    }
}
