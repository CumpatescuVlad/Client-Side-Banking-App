using Newtonsoft.Json;
namespace ClientSideApp
{
    public partial class StandingOrderTab : UserControl
    {
        private readonly BallanceOperations ballanceOperation = new();
        public StandingOrderTab()
        {
            InitializeComponent();
            selectAccountBox.GotFocus += SelectAccountBox_GotFocus;
        }

        private void SelectAccountBox_GotFocus(object? sender, EventArgs e)
        {
            AccountData accountData = JsonConvert.DeserializeObject<AccountData>(Temp.ReadFile("AccountData.json"));

            selectAccountBox.Items.Add(accountData.AccountName);
        }



        private void StandingOrderTab_Load(object sender, EventArgs e)
        {

            #region UIComponents
            selectAccountBox.Show();
            selectAccountLBL.Show();
            amountLbl.Hide();
            amountBox.Hide();
            startingDateBox.Hide();
            startingDateLbl.Hide();
            nextBtnTwo.Hide();
            nextBtnThree.Hide();
            button1.Show();
            #endregion

        }

        #region Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            if (Box.IsEmpty(IBANBox))
            {
                return;
            }

            else if (IBANBox.Text.Length > 24 || IBANBox.Text.Length < 24)
            {
                MessageBox.Show($"IBAN Code Cannot be longer than 24 Chars.\nYou Introduced {IBANBox.Text.Length} chars.");

                IBANBox.Clear();

                return;

            }

            else if (IBANBox.Text.Length == 24)
            {
                ShowAmountTab();
                ShowAmountTab();
                nextBtnTwo.Show();
                button1.Hide();
            }

        }

        private void nextBtnTwo_Click(object sender, EventArgs e)
        {
            if (Box.IsEmpty(amountBox))
            {
                return;
            }

            else if (Box.IsNumber(amountBox) is false)
            {
                return;
            }

            else if (Box.HasText(amountBox))
            {
                ShowDateTab();
                nextBtnTwo.Hide();
                nextBtnThree.Show();
            }

        }

        private void nextBtnThree_Click(object sender, EventArgs e)
        {
            if (Box.IsEmpty(startingDateBox))
            {
                return;
            }

            else if (Box.IsNumber(startingDateBox) is false)
            {
                return;
            }

            else if (Box.HasText(startingDateBox))
            {
                //Execute DEbit Periodically

                CommitStandingOrder();

                #region UIElements
                selectAccountBox.Show();
                selectAccountLBL.Show();
                IBANBox.Show();
                IBANLbl.Show();
                amountBox.Hide();
                amountLbl.Hide();
                startingDateBox.Hide();
                startingDateLbl.Hide();
                nextBtnThree.Hide();
                nextBtnTwo.Hide();
                button1.Show();
                startingDateLbl.Hide();
                IBANBox.Clear();
                amountBox.Clear();
                startingDateBox.Clear();
                #endregion

                this.Hide();
            }



        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            #region HideElements
            selectAccountBox.Show();
            selectAccountLBL.Show();
            IBANBox.Clear();
            IBANBox.Show();
            IBANLbl.Show();
            amountLbl.Hide();
            amountBox.Hide();
            startingDateBox.Hide();
            startingDateLbl.Hide();
            button1.Show();
            #endregion

            this.Hide();
        }

        #endregion

        #region Unmanaged
        private void ShowAmountTab()
        {
            #region UICompnents
            selectAccountBox.Hide();
            selectAccountLBL.Hide();
            IBANBox.Hide();
            IBANLbl.Hide();
            amountLbl.Show();
            amountBox.Show();
            amountLbl.BringToFront();
            amountBox.BringToFront();
            #endregion

            //button1.Hide();
            //nextBtnTwo.Show();

        }

        private void ShowDateTab()
        {
            #region UIComponents
            selectAccountBox.Hide();
            selectAccountLBL.Hide();
            amountBox.Hide();
            amountLbl.Hide();
            startingDateBox.Show();
            startingDateLbl.Show();
            #endregion

        }

        private void CommitStandingOrder()
        {
            //commit trannsfer an account to another with quartz

            AccountData accountData = JsonConvert.DeserializeObject<AccountData>(Temp.ReadFile("AccountData.json"));

            if (ballanceOperation.ReadSenderAccountBalance("Amount", "Accounts", "AccountIBAN", accountData.AccountIBAN) < int.Parse(amountBox.Text))
            {
                MessageBox.Show("Not Enough Funds!!");

                amountBox.Clear();

                return;
            }

            ballanceOperation.ExecuteTransfer("Amount", "Accounts", "AccountIBAN", IBANBox.Text, int.Parse(amountBox.Text));

            ballanceOperation.UpdateSenderBallance("Accounts", int.Parse(amountBox.Text), ballanceOperation.ReadSenderAccountBalance("Amount", "Accounts", "AccountIBAN", accountData.AccountIBAN), "AccountIBAN", accountData.AccountIBAN);

            ballanceOperation.RegisterReciverTransaction(IBANBox.Text, int.Parse(amountBox.Text), accountData.AccountIBAN);

            ballanceOperation.RegisterSenderTransactions("CustomerName,CustomerAccountNo,CustomerIBAN,CustomerAccountName,Amount,Date,TransactionType,IBAN", $"'{accountData.CustomerName}','{accountData.AccountNumber}','{accountData.AccountIBAN}','{accountData.AccountName}','{amountBox.Text}','{DateTime.Now}','Transfered','{IBANBox.Text}'");

            accountData.Balance = ballanceOperation.ReadSenderAccountBalance("Amount", "Accounts", "AccountIBAN", accountData.AccountIBAN);

            this.Hide();

        }
        #endregion


    }
}
