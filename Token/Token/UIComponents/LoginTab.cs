using Newtonsoft.Json;
using Token.BackEndComponents;

namespace Token
{
    public partial class LoginTab : UserControl
    {
        #region Objects
        private readonly Communication communication = new();
        private readonly Credentials credentials = new();
        private readonly ExtractData data = new();
        #endregion

        public LoginTab()
        {
            InitializeComponent();
            phoneNUmLbl.Click += PhoneNUmLbl_Click;
            EmailLbl.Click += EmailLbl_Click;
            phoneNUmLbl.MouseEnter += PhoneNUmLbl_MouseEnter;
            phoneNUmLbl.MouseLeave += PhoneNUmLbl_MouseLeave;
            EmailLbl.MouseEnter += EmailLbl_MouseEnter;
            EmailLbl.MouseLeave += EmailLbl_MouseLeave;
            sendAgain.Click += SendAgain_Click;

        }

        #region LoginBtns
        private void button1_Click(object sender, EventArgs e)
        {
            #region ImputCheck
            if (Errors.BoxIsEmpty(fullNameBox.Text) is true)
            {
                return;
            }

            else if (Errors.IsNumber(fullNameBox) is true)
            {
                MessageBox.Show("Name Cannot Contain Numbers.");

                fullNameBox.Clear();

                return;
            }
            #endregion

            if (data.ReadUserData(fullNameBox.Text) is null)
            {
                MessageBox.Show("CustomerNotFound!!");

                fullNameBox.Clear();

                return;
            }
            if (data.isFirstInstall(fullNameBox.Text) is true)
            {
                #region ShowActivationTab
                label1.Text = "Activate App";
                phoneNUmLbl.Show();
                EmailLbl.Show();
                button1.Hide();
                #endregion

            }
            else
            {
                #region ShowNormalTab

                button1.Hide();
                passwordLbl.Show();
                passwordBox.Show();
                phoneNUmLbl.Hide();
                phoneNUmLbl.Dispose();
                EmailLbl.Hide();
                EmailLbl.Dispose();
                loginBtnTwo.Hide();
                loginBtnThree.Show();
                #endregion

            }
            Temp.CreateFile("CustomerData.json", JsonConversion.SerializeData(data.ReadUserData(fullNameBox.Text)));
            Temp.CopyFile("CustomerData.json");
        }

        private void loginBtnTwo_Click(object sender, EventArgs e)
        {
            if (data.ReadUserData(fullNameBox.Text) is null)
            {
                MessageBox.Show("CustomerNotFound!!");

                fullNameBox.Clear();

                return;
            }

            if (Errors.BoxIsEmpty(passwordBox.Text) is true)
            {
                return;
            }

            Temp.CreateFile("CustomerData.json", JsonConversion.SerializeData(data.ReadUserData(fullNameBox.Text)));
            Temp.CopyFile("CustomerData.json");
            if (credentials.isMatching(fullNameBox, passwordBox) is true)
            {
                #region CredentialsChangingTab
                appAccountManagement1.BringToFront();
                appAccountManagement1.Show();
                phoneNUmLbl.Dispose();
                EmailLbl.Dispose();
                passwordBox.Dispose();
                fullNameBox.Dispose();
                label1.Dispose();
                label2.Dispose();
                #endregion

            }
            else
            {
                wrongPassword.Text = "Worng Password";
                passwordBox.Clear();
                return;
            }


        }

        private void loginBtnThree_Click(object sender, EventArgs e)
        {
            if (Errors.BoxIsEmpty(passwordBox.Text) is true)
            {
                return;
            }

            if (credentials.isMatching(fullNameBox, passwordBox) is true)
            {
                #region CredentialsChagingTab
                appAccountManagement1.BringToFront();
                appAccountManagement1.Show();
                phoneNUmLbl.Dispose();
                EmailLbl.Dispose();
                passwordBox.Dispose();
                fullNameBox.Dispose();
                label1.Dispose();
                label2.Dispose();

                #endregion

            }
            else
            {
                wrongPassword.Text = "Worng Password";
                passwordBox.Clear();
                return;
            }


        }
        #endregion

        #region CommunicationLbls
        private void EmailLbl_Click(object? sender, EventArgs e)
        {
            CustomerData customerData = JsonConvert.DeserializeObject<CustomerData>(Temp.ReadFile("CustomerData.json"));
            communication.SendEmail(customerData.CustomerEmail, customerData.CustomerPassword);
            MessageBox.Show($"We sent an email to {customerData.CustomerEmail} in which you find the password.");

            #region UI
            loginBtnTwo.Show();
            passwordLbl.Show();
            passwordBox.Show();
            phoneNUmLbl.Hide();
            EmailLbl.Hide();
            phoneNUmLbl.Dispose();
            EmailLbl.Dispose();
            sendAgain.Show();
            #endregion
        }

        private void SendAgain_Click(object? sender, EventArgs e)
        {
            CustomerData customerData = JsonConvert.DeserializeObject<CustomerData>(Temp.ReadFile("CustomerData.json"));
            sendAgain.ForeColor = Color.DeepSkyBlue;
            communication.SendEmail(customerData.CustomerEmail, customerData.CustomerPassword);
            MessageBox.Show("Email Was Sent Again.");
        }

        private void PhoneNUmLbl_Click(object? sender, EventArgs e)
        {
            ResponseCodes _responseCode = JsonConvert.DeserializeObject<ResponseCodes>(Temp.ReadFile("SmsResponseCode.json"));
            CustomerData customerData = JsonConvert.DeserializeObject<CustomerData>(Temp.ReadFile("CustomerData.json"));
            communication.SendSMS(customerData.CustomerPhoneNumber, customerData.CustomerPassword);
            if (int.Parse(_responseCode.responseCode) >= 200)
            {
                MessageBox.Show($"We sent a message to {customerData.CustomerPhoneNumber} , in which you find the password.");
            }

            #region UI
            loginBtnTwo.Show();
            passwordLbl.Show();
            passwordBox.Show();
            phoneNUmLbl.Hide();
            EmailLbl.Hide();
            phoneNUmLbl.Dispose();
            EmailLbl.Dispose();
            #endregion

        }
        #endregion


        #region UIBehaviour

        private void EmailLbl_MouseLeave(object? sender, EventArgs e)
        {
            EmailLbl.ForeColor = Color.Black;
        }

        private void EmailLbl_MouseEnter(object? sender, EventArgs e)
        {
            EmailLbl.ForeColor = Color.Green;
        }

        private void PhoneNUmLbl_MouseLeave(object? sender, EventArgs e)
        {
            phoneNUmLbl.ForeColor = Color.Black;
        }

        private void PhoneNUmLbl_MouseEnter(object? sender, EventArgs e)
        {
            phoneNUmLbl.ForeColor = Color.Green;
        }

        private void LoginTab_Load(object sender, EventArgs e)
        {

            loginBtnThree.Hide();
            loginBtnTwo.Hide();
            phoneNUmLbl.Hide();
            EmailLbl.Hide();
            appAccountManagement1.Hide();
            passwordBox.Hide();
            passwordLbl.Hide();
            sendAgain.Hide();
        }
        #endregion


    }
}
