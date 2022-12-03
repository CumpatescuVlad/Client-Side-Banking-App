using ClientSideApp.src;
using Newtonsoft.Json;

namespace ClientSideApp
{
    public partial class OverviewTab : UserControl
    {
        private readonly ExtractData customerData = new();
        CustomerData _customerData = JsonConvert.DeserializeObject<CustomerData>(Temp.ReadTokenFiles("CustomerData.json"));
        //AccountData accountData = JsonConvert.DeserializeObject<AccountData>(Temp.ReadFile("AccountData.json"));
        public OverviewTab()
        {
            InitializeComponent();
            richTextBox1.Click += RichTextBox1_Click;
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            this.VisibleChanged += OverviewTab_VisibleChanged;

        }

        private void OverviewTab_VisibleChanged(object? sender, EventArgs e)
        {
            greetMessage.Text = $"Hello {_customerData.CustomerFullName}";
            //richTextBox1.Text = $"Current Account:{customerData.ReadAccountData(_customerData.CustomerFullName)} availabble {accountData.Balance} RON";

        }

        private void newTransferBtn_Click(object sender, EventArgs e)
        {

            newTransferTab1.Show();
            newTransferTab1.BringToFront();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_Click(object? sender, EventArgs e)
        {
            button1.Show();
            transactionsLogTab1.Show();
            transactionsLogTab1.BringToFront();

        }

        private void transactionsLogTab1_Load(object sender, EventArgs e)
        {

        }

        private void OverviewTab_Load(object sender, EventArgs e)
        {


            #region UIElements
            transactionsLogTab1.Hide();
            button1.Hide();
            newTransferTab1.Hide();
            #endregion

        }



        private void button1_Click(object sender, EventArgs e)
        {
            #region UI
            transactionsLogTab1.Hide();
            newTransferTab1.Hide();
            this.Show();
            this.BringToFront();
            button1.Hide();
            #endregion

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //richTextBox1.Text = customerData.ReadCustomerAccounts(Temp.ReadFile("CustomerFullName.txt"));
        }
    }
}
