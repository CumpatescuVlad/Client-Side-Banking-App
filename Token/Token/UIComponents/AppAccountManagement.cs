using Newtonsoft.Json;
using Token.BackEndComponents;

namespace Token
{
    public partial class AppAccountManagement : UserControl
    {
        #region Objects
        private readonly ChangeUserCredentials data = new();
        private readonly ExtractData extract = new();
        #endregion

        public AppAccountManagement()
        {
            InitializeComponent();

        }

        private void passwprdBTn_Click(object sender, EventArgs e)
        {
            if (Errors.BoxIsEmpty(passBox.Text) is true)
            {
                return;
            }

            data.ChangePassword(passBox.Text, succes);

            passBox.Clear();

        }

        private void pinBtn_Click(object sender, EventArgs e)
        {
            if (Errors.BoxIsEmpty(pinBox.Text) is true)
            {
                return;
            }
            else if (Errors.IsNumber(pinBox) is true && Errors.HasFiveOrMoreNumbers(pinBox) is true)
            {
                MessageBox.Show("Pin Cannot Contain More Than Four Numbers.");

                return;
            }

            else if (Errors.IsNumber(pinBox) is false)
            {
                MessageBox.Show("PIN Code Cannot Contain Letters.");

                pinBox.Clear();

                return;
            }

            data.ChangePIN(pinBox.Text, succes);

            pinBox.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerData customerData = JsonConvert.DeserializeObject<CustomerData>(Temp.ReadFile("CustomerData.json"));
            Temp.CreateFile("CustomerData.json", JsonConversion.SerializeData(extract.ReadUserData(customerData.CustomerFullName)));
            Temp.CopyFile("CustomerData.json");
            Environment.Exit(0);

        }
    }
}
