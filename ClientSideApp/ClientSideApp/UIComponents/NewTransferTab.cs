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

        //private void ExecuteTransfer(string IBAN, int amount)
        //{
        //    int reciverAccountBallance = 0;
        //    connection.Open();

        //    var readReciverBallance = new SqlCommand(DataSelection.
        //        SelectData("Amount", "Accounts", "AccountIBAN", IBAN), connection);

        //    var reader = readReciverBallance.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        reciverAccountBallance = reader.GetInt32(0);
        //    }
        //    reader.Close();

        //    var updateAmountCommand = new SqlCommand(DataSelection.UpdateAmount(IBAN, reciverAccountBallance + amount), connection);

        //    var updateAmount = new SqlDataAdapter(updateAmountCommand) { UpdateCommand = updateAmountCommand };

        //    updateAmount.UpdateCommand.ExecuteNonQuery();

        //    connection.Close();

        //    #region Object Disposing 
        //    updateAmount.Dispose();
        //    updateAmountCommand.Dispose();
        //    #endregion

        //}

        //private void UpdateSenderBallance(string IBAN, int amount, int senderBallance)
        //{
        //    connection.Open();

        //    var updateBallance = new SqlCommand(DataSelection.UpdateAmount(IBAN, senderBallance - amount), connection);

        //    var adapter = new SqlDataAdapter() { UpdateCommand = updateBallance };

        //    adapter.UpdateCommand.ExecuteNonQuery();

        //    connection.Close();

        //}

        //private int ReadSenderAccountBalance(string IBAN)
        //{
        //    int senderAccountBallance = 0;

        //    connection.Open();

        //    var readCurrentBallance = new SqlCommand(DataSelection.
        //        SelectData("Amount", "Accounts", "AccountIBAN", IBAN), connection);

        //    var reader = readCurrentBallance.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        senderAccountBallance = reader.GetInt32(0);
        //    }

        //    connection.Close();

        //    return senderAccountBallance;
        //}

        //private void RegisterReciverTransaction(string IBAN, int amount, string senderIBAN)
        //{

        //    var readReciverAccountData = new SqlCommand(DataSelection.
        //        SelectData("CustomerName,AccountIBAN,AccountNumber,AccountName", "Accounts", "AccountIBAN", IBAN), connection);

        //    connection.Open();

        //    var reader = readReciverAccountData.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        reciverAccountData.CustomerName = reader.GetString(0);
        //        reciverAccountData.AccountIBAN = reader.GetString(1);
        //        reciverAccountData.AccountNumber = reader.GetString(2);
        //        reciverAccountData.AccountName = reader.GetString(3);

        //    }
        //    reader.Close();

        //    var insertReciverTransaction = new SqlCommand(DataSelection.
        //        InsertData("CustomerName,CustomerAccountNo,CustomerIBAN,CustomerAccountName,Amount,Date,TransactionType,IBAN", $"'{reciverAccountData.CustomerName}','{reciverAccountData.AccountNumber}','{reciverAccountData.AccountIBAN}','{reciverAccountData.AccountName}','{amount}','{DateTime.Now}','Recived','{senderIBAN}'"), connection);

        //    var adapter = new SqlDataAdapter() { InsertCommand = insertReciverTransaction };

        //    adapter.InsertCommand.ExecuteNonQuery();

        //    connection.Close();

        //}

        //private void RegisterSenderTransactions(string colums, string values)
        //{
        //    var insertsenderTransaction = new SqlCommand(DataSelection.InsertData(colums, values), connection);

        //    connection.Open();

        //    var adapter = new SqlDataAdapter() { InsertCommand = insertsenderTransaction };

        //    adapter.InsertCommand.ExecuteNonQuery();

        //    connection.Close();

        //}





    }






}

