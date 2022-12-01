using Microsoft.Data.SqlClient;

namespace Token.UnderTheHood
{
    public class ChangeData
    {
        private readonly SqlConnection connection = new SqlConnection(Data.ConnectionString);


        public void ChangePassword(string newPassword, Label succesLabel)
        {
            var updatePasswordCommand = new SqlCommand(Data.ChangePassword(Temp.ReadFile("CustomerFullName.txt"), newPassword), connection);
            var setFirstInstallToFalseCommand = new SqlCommand(Data.ChangeFirstInstall(Temp.ReadFile("CustomerFullName.txt")), connection);

            connection.Open();

            var adapter = new SqlDataAdapter(updatePasswordCommand);
            var secondAdpter = new SqlDataAdapter(setFirstInstallToFalseCommand)
            {
                UpdateCommand = setFirstInstallToFalseCommand
            };
            secondAdpter.UpdateCommand.ExecuteNonQuery();

            adapter.UpdateCommand = updatePasswordCommand;
            adapter.UpdateCommand.ExecuteNonQuery();
            succesLabel.Text = "Password Was Succesfully Changed!";

            connection.Close();
            Temp.CreateFile("CustomerPassword.txt", newPassword);
            #region ObjectDisposing
            adapter.Dispose();
            secondAdpter.Dispose();
            updatePasswordCommand.Dispose();
            setFirstInstallToFalseCommand.Dispose();
            #endregion

        }
        public void ChangePIN(string newPin, Label succesLabel)
        {
            var changePINCommand = new SqlCommand(Data.ChangePIN(Temp.ReadFile("CustomerFullName.txt"), newPin), connection);
            var setFirstInstallToFalseCommand = new SqlCommand(Data.ChangeFirstInstall(Temp.ReadFile("CustomerFullName.txt")), connection);
            connection.Open();

            var adapter = new SqlDataAdapter
            {
                UpdateCommand = changePINCommand
            };

            adapter.UpdateCommand.ExecuteNonQuery();

            var secondAdapter = new SqlDataAdapter { UpdateCommand = setFirstInstallToFalseCommand };

            secondAdapter.UpdateCommand.ExecuteNonQuery();

            succesLabel.Text = "PIN Was Succesfully Changed!";

            connection.Close();

            Temp.CreateFile("CustomerAppPIN.txt", newPin);

            #region ObjectDisposing
            adapter.Dispose();
            changePINCommand.Dispose();
            changePINCommand.Dispose();
            #endregion


        }
    }
}
