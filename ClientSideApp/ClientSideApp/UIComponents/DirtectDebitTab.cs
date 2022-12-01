using Newtonsoft.Json;

namespace ClientSideApp
{
    public partial class DirtectDebitTab : UserControl
    {
        private readonly ExtractData extractData = new();
        private readonly BallanceOperations ballanceOperation = new();
        public DirtectDebitTab()
        {
            InitializeComponent();
            CompanyBox.GotFocus += CompanyBox_GotFocus;
            yourAccountBox.GotFocus += YourAccountBox_GotFocus;
            CompanyBox.LostFocus += CompanyBox_LostFocus;
            ibanCombo.LostFocus += IbanCombo_LostFocus;

        }

        private void IbanCombo_LostFocus(object? sender, EventArgs e)
        {
            ibanCombo.Items.Clear();

        }

        private void CompanyBox_LostFocus(object? sender, EventArgs e)
        {
            CompanyBox.Items.Clear();

        }

        private void YourAccountBox_GotFocus(object? sender, EventArgs e)
        {
            AccountData accountData = JsonConvert.DeserializeObject<AccountData>(Temp.ReadFile("AccountData.json"));

            yourAccountBox.Items.Add(accountData.AccountName);
        }

        private void CompanyBox_GotFocus(object? sender, EventArgs e)
        {
            extractData.ReadCompanyAccounts(CompanyBox, ibanCombo);

        }

        private void DirtectDebitTab_Load(object sender, EventArgs e)
        {
            selectAccountLbl.Show();
            yourAccountBox.Show();

            #region HideItems
            amountLbl.Hide();
            amountBox.Hide();
            amountBox.Clear();
            CompanyBox.Show();
            companyIBANLbl.Show();
            enterDebitPeriodLbl.Hide();
            startingDateBox.Hide();
            startingDateBox.Clear();
            StartingDateLbl.Hide();
            nextBtnTwo.Hide();
            nextBtnThree.Hide();
            #endregion

        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(CompanyBox.Text) || String.IsNullOrEmpty(yourAccountBox.Text))
            {
                MessageBox.Show("Please Select A Value!!");
                return;
            }

            ShowAmountTab();

            nextBtnTwo.Show();

            #region HideItems
            yourAccountBox.Hide();
            selectAccountLbl.Hide();
            nextBtn.Hide();
            ibanCombo.Hide();
            #endregion


        }


        private void nextBtnTwo_Click(object sender, EventArgs e)
        {
            if (Box.IsEmpty(amountBox))
            {
                return;
            }

            if (Box.IsNumber(amountBox) is false)
            {
                return;
            }

            if (Box.HasText(amountBox))
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
            if (Box.IsNumber(startingDateBox) is false)
            {
                startingDateBox.Clear();

                return;
            }

            if (Box.HasText(startingDateBox))
            {
                //Execute DEbit Periodically

                AccountData accountData = JsonConvert.DeserializeObject<AccountData>(Temp.ReadFile("AccountData.json"));

                if (ballanceOperation.ReadSenderAccountBalance("Amount", "Accounts", "AccountIBAN", accountData.AccountIBAN) < int.Parse(amountBox.Text))
                {
                    MessageBox.Show("Not Enough Funds!!");

                    amountBox.Clear();

                    return;
                }

                ballanceOperation.ExecuteTransfer("Amount", "CompaniesAccounts", "CompanyIBAN", $"{ibanCombo.Text}", int.Parse(amountBox.Text));

                ballanceOperation.UpdateSenderBallance("Accounts", int.Parse(amountBox.Text), ballanceOperation.ReadSenderAccountBalance("Amount", "Accounts", "AccountIBAN", accountData.AccountIBAN), "AccountIBAN", accountData.AccountIBAN);

                ballanceOperation.RegisterSenderTransactions("CustomerName,CustomerAccountNo,CustomerIBAN,CustomerAccountName,Amount,Date,TransactionType,IBAN", $"'{accountData.CustomerName}','{accountData.AccountNumber}','{accountData.AccountIBAN}','{accountData.AccountName}','{amountBox.Text}','{DateTime.Now}','Bill Payment','{ibanCombo.Text}'");

                accountData.Balance = ballanceOperation.ReadSenderAccountBalance("Amount", "Accounts", "AccountIBAN", accountData.AccountIBAN);




                #region UIElements
                yourAccountBox.Show();
                selectAccountLbl.Show();
                CompanyBox.Show();
                companyIBANLbl.Show();
                amountBox.Hide();
                amountLbl.Hide();
                startingDateBox.Hide();
                StartingDateLbl.Hide();
                nextBtnThree.Hide();
                nextBtnTwo.Hide();
                nextBtn.Show();
                enterDebitPeriodLbl.Hide();
                amountBox.Clear();
                startingDateBox.Clear();
                CompanyBox.Items.Clear();
                #endregion

                this.Hide();


            }

        }


        private void ShowAmountTab()
        {
            companyIBANLbl.Hide();
            CompanyBox.Hide();
            amountLbl.Show();
            amountBox.Show();
        }

        private void ShowDateTab()
        {
            amountBox.Hide();
            amountLbl.Hide();
            enterDebitPeriodLbl.Show();
            startingDateBox.Show();
            StartingDateLbl.Show();



        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            #region UIElements
            CompanyBox.Show();
            companyIBANLbl.Show();
            selectAccountLbl.Show();
            yourAccountBox.Show();
            amountBox.Hide();
            amountLbl.Hide();
            startingDateBox.Hide();
            StartingDateLbl.Hide();
            nextBtnThree.Hide();
            nextBtnTwo.Hide();
            nextBtn.Show();
            enterDebitPeriodLbl.Hide();
            #endregion

            this.Hide();
        }

    }
}
