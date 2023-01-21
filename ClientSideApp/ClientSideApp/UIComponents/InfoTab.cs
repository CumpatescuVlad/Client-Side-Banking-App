using ClientSideApp.src;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Data.SqlClient;
using MimeKit;
using Newtonsoft.Json;

namespace ClientSideApp
{
    public partial class InfoTab : UserControl
    {
        CustomerData _customerData = JsonConvert.DeserializeObject<CustomerData>(Temp.ReadTokenFiles("CustomerData.json"));
        private readonly SqlConnection connection = new(DataSelection.ConnectionString);
        private readonly MimeMessage message = new();
        private readonly SmtpClient emailClient = new();
        public InfoTab()
        {
            InitializeComponent();
            this.MouseEnter += InfoTab_MouseEnter;


        }

        private void InfoTab_MouseEnter(object? sender, EventArgs e)
        {
            bool labelsAreEmpty = String.IsNullOrEmpty(accountTypeContent.Text) || String.IsNullOrEmpty(accountOwnerContent.Text)
                                  || String.IsNullOrEmpty(ibanContent.Text) || String.IsNullOrEmpty(AvailabbleAmountContent.Text);
            if (labelsAreEmpty is true)
            {
                accountTypeContent.Text = "Current Account";

                accountOwnerContent.Text = _customerData.CustomerFullName;

                ReadAccountData(_customerData.CustomerFullName, ibanContent, AvailabbleAmountContent);
            }

        }

        private void InfoTab_Load(object sender, EventArgs e)
        {
            button1.Hide();

        }

        private void shareAccountInfo_Click(object sender, EventArgs e)
        {
            SendEmail(_customerData.CustomerEmail);

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

            message.To.Add(MailboxAddress.Parse(customerName));

            message.Subject = "Account Info";

            message.Body = new TextPart("plain")
            {
                Text = $"{label2.Text}:{accountOwnerContent.Text}\n{label3.Text}:{ibanContent.Text}"
            };

            emailClient.Connect("smtp-relay.sendinblue.com", 587, SecureSocketOptions.StartTls);

            emailClient.Authenticate("Cumpatescuvlad@yahoo.com", "3ANj6M2JskzQG4cX");

            emailClient.Send(message);


        }

    }
}
