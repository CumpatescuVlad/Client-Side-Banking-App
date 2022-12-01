using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Data.SqlClient;
using MimeKit;

namespace ClientSideApp
{
    public partial class InfoTab : UserControl
    {
        private readonly SqlConnection connection = new(DataSelection.ConnectionString);
        private readonly MimeMessage message = new();
        private readonly SmtpClient emailClient = new();
        public InfoTab()
        {
            InitializeComponent();
            exchangeLbl.Click += ExchangeLbl_Click;


        }

        private void ExchangeLbl_Click(object? sender, EventArgs e)
        {
            //Show Exchange Here

            #region UIElements
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            accountOwnerContent.Hide();
            accountTypeContent.Hide();
            ibanContent.Hide();
            AvailabbleAmountContent.Hide();
            button1.Show();
            shareAccountInfo.Hide();
            #endregion


        }

        private void InfoTab_Load(object sender, EventArgs e)
        {

            accountTypeContent.Text = "Current Account";

            accountOwnerContent.Text = Temp.ReadFile("CustomerFullName.txt");

            ReadAccountData(Temp.ReadFile("CustomerFullName.txt"), ibanContent, AvailabbleAmountContent);

            button1.Hide();

        }

        private void shareAccountInfo_Click(object sender, EventArgs e)
        {
            SendEmail(Temp.ReadFile("CustomerFullName.txt"));

            MessageBox.Show("Info Shared!!");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region UIElements
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            accountOwnerContent.Show();
            accountTypeContent.Show();
            ibanContent.Show();
            AvailabbleAmountContent.Show();
            button1.Hide();
            shareAccountInfo.Show();
            #endregion

        }

        private void ReadAccountData(string customerName, Label IBAN, Label amount)
        {
            var readAccountInfo = new SqlCommand(DataSelection.SelectData("AccountIBAN , Amount", "Accounts", "CustomerName", customerName), connection);

            connection.Open();

            var reader = readAccountInfo.ExecuteReader();

            while (reader.Read())
            {
                IBAN.Text = reader.GetString(0);

                amount.Text = $"{reader.GetInt32(1)}";
            }
            connection.Close();
            readAccountInfo.Dispose();
            reader.Close();

        }
        private void SendEmail(string customerName)
        {
            message.From.Add(new MailboxAddress("BANK-APP", "cumpatescuvlad@yahoo.com"));

            message.To.Add(MailboxAddress.Parse(ReadCustomerEmail(customerName)));

            message.Subject = "Account Info";

            message.Body = new TextPart("plain")
            {
                Text = $"{label2.Text}:{accountOwnerContent.Text}\n{label3.Text}:{ibanContent.Text}"
            };

            emailClient.Connect("smtp-relay.sendinblue.com", 587, SecureSocketOptions.StartTls);

            emailClient.Authenticate("Cumpatescuvlad@yahoo.com", "3ANj6M2JskzQG4cX");

            emailClient.Send(message);


        }
        private string ReadCustomerEmail(string customerName)
        {
            string customerEmail = null;

            var readEmailCommand = new SqlCommand(DataSelection.SelectData("CustomerEmail", "Customers", "CustomerFullName", customerName), connection);

            connection.Open();

            var reader = readEmailCommand.ExecuteReader();

            while (reader.Read())
            {
                customerEmail = reader.GetString(0);
            }

            connection.Close();
            readEmailCommand.Dispose();
            reader.Close();

            return customerEmail;
        }
    }
}
