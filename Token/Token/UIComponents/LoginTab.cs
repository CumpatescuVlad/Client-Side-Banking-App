using Token.UnderTheHood;

namespace Token
{
    public partial class LoginTab : UserControl
    {
        private readonly ExtractData data = new();
        private readonly Communication communication = new();
        private readonly Credentials credentials = new();

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

        private void SendAgain_Click(object? sender, EventArgs e)
        {
            sendAgain.ForeColor = Color.DeepSkyBlue;
            communication.SendEmail(Temp.ReadFile("CustomerEmail.txt"), Temp.ReadFile("CustomerPassword.txt"));
            MessageBox.Show("Email Was Sent Again.");
        }




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

        private void EmailLbl_Click(object? sender, EventArgs e)
        {
            communication.SendEmail(Temp.ReadFile("CustomerEmail.txt"), Temp.ReadFile("CustomerPassword.txt"));
            MessageBox.Show($"We sent an email to {Temp.ReadFile("CustomerEmail.txt")} in which you find the password.");
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

        private void PhoneNUmLbl_Click(object? sender, EventArgs e)
        {
            communication.SendSMS(Temp.ReadFile("CustomerPhoneNumber.txt"), Temp.ReadFile("CustomerPassword.txt"));

            MessageBox.Show($"We sent a message to {Temp.ReadFile("CustomerPhoneNumber.txt")} , in which you find the password.");

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



        private void button1_Click(object sender, EventArgs e)
        {
            #region ImputCheck
            if (Errors.BoxIsEmpty(fullNameBox.Text) is true)
            {
                return;
            }

            if (Errors.IsNumber(fullNameBox) is true)
            {
                MessageBox.Show("Name Cannot Contain Numbers.");

                fullNameBox.Clear();

                return;
            }
            #endregion

            if (data.isFirstInstall(fullNameBox.Text) is true)
            {
                #region ShowActivationTab
                label1.Text = "Activate App";
                phoneNUmLbl.Show();
                EmailLbl.Show();
                button1.Hide();
                data.ReadPassword(fullNameBox.Text);
                #endregion

            }
            else
            {
                #region ShowNormalTab
                data.ReadPassword(fullNameBox.Text);
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

        }

        private void loginBtnTwo_Click(object sender, EventArgs e)
        {
            if (Errors.BoxIsEmpty(passwordBox.Text) is true)
            {
                return;
            }

            data.ReadPassword(fullNameBox.Text);

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
    }
}
