using Newtonsoft.Json;

namespace ClientSideApp
{
    public partial class NewTransferTab : UserControl
    {

        private readonly BallanceOperations ballanceOperation = new();

        public NewTransferTab()
        {
            InitializeComponent();
            textBox3.GotFocus += TextBox3_GotFocus;
            comboBox1.GotFocus += ComboBox1_GotFocus;

        }

        private void ComboBox1_GotFocus(object? sender, EventArgs e)
        {
            AccountData account = JsonConvert.DeserializeObject<AccountData>(Temp.ReadFile("AccountData.json"));

            comboBox1.Items.Add(account.AccountName);

        }

        private void NewTransferTab_Load(object sender, EventArgs e)
        {
            textBox3.Text = "Optional";


        }

        private void TextBox3_GotFocus(object? sender, EventArgs e)
        {

            if (textBox3.Text != "Optional")
            {
                return;
            }
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Box.IsEmpty(textBox1) || Box.IsEmpty(textBox2) || Box.IsEmpty(textBox3))
            {
                return;
            }

            AccountData accountData = JsonConvert.DeserializeObject<AccountData>(Temp.ReadFile("AccountData.json"));

            if (ballanceOperation.ReadSenderAccountBalance("Amount", "Accounts", "AccountIBAN", accountData.AccountIBAN) < int.Parse(textBox2.Text))
            {
                MessageBox.Show("Not Enough Funds!!");

                textBox2.Clear();
                return;
            }

            ballanceOperation.ExecuteTransfer("Amount", "Accounts", "AccountIBAN", textBox1.Text, int.Parse(textBox2.Text));

            ballanceOperation.UpdateSenderBallance("Accounts", int.Parse(textBox2.Text), ballanceOperation.ReadSenderAccountBalance("Amount", "Accounts", "AccountIBAN", accountData.AccountIBAN), "AccountIBAN", accountData.AccountIBAN);

            ballanceOperation.RegisterReciverTransaction(textBox1.Text, int.Parse(textBox2.Text), accountData.AccountIBAN);

            ballanceOperation.RegisterSenderTransactions("CustomerName,CustomerAccountNo,CustomerIBAN,CustomerAccountName,Amount,Date,TransactionType,IBAN", $"'{accountData.CustomerName}','{accountData.AccountNumber}','{accountData.AccountIBAN}','{accountData.AccountName}','{textBox2.Text}','{DateTime.Now}','Transfered','{textBox1.Text}'");

            accountData.Balance = ballanceOperation.ReadSenderAccountBalance("Amount", "Accounts", "AccountIBAN", accountData.AccountIBAN);

            textBox2.Clear();
            textBox3.Text = "Optional";
            backBtbn.Hide();
            this.Hide();

        }

        private void backBtbn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Text = "Optional";
            this.Hide();
        }


    }






}

