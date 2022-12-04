using ClientSideApp.src;
using Newtonsoft.Json;

namespace ClientSideApp
{
    public partial class TransactionsLogTab : UserControl
    {
        private readonly ExtractData extractdata = new();
        public TransactionsLogTab()
        {
            InitializeComponent();
            richTextBox1.MouseEnter += RichTextBox1_MouseEnter;
        }

        private void RichTextBox1_MouseEnter(object? sender, EventArgs e)
        {
            CustomerData customerData = JsonConvert.DeserializeObject<CustomerData>(Temp.ReadTokenFiles("CustomerData.json"));
            if (String.IsNullOrEmpty(richTextBox1.Text))
            {
                richTextBox1.Text = "Searching Transactions";
                richTextBox1.Text = extractdata.ReadCustomerTransactions(customerData.CustomerFullName);
            }
        }

        private void TransactionsLogTab_Load(object sender, EventArgs e)
        {
            #region UIComponenets
            transactionsBtn.BackColor = Color.White;
            infoBtn.BackColor = Color.WhiteSmoke;
            functionsBtn.BackColor = Color.WhiteSmoke;
            functionsTab1.Hide();
            infoTab1.Hide();
            #endregion

        }

        private void functionsBtn_Click(object sender, EventArgs e)
        {
            #region UIComponenets
            functionsBtn.BackColor = Color.White;
            transactionsBtn.BackColor = Color.WhiteSmoke;
            infoBtn.BackColor = Color.WhiteSmoke;
            richTextBox1.Hide();
            richTextBox1.Enabled = false;
            functionsTab1.Show();
            functionsTab1.BringToFront();
            #endregion

        }

        private void transactionsBtn_Click(object sender, EventArgs e)
        {
            #region UIComponents
            transactionsBtn.BackColor = Color.White;
            infoBtn.BackColor = Color.WhiteSmoke;
            functionsBtn.BackColor = Color.WhiteSmoke;
            richTextBox1.Show();
            richTextBox1.BringToFront();
            richTextBox1.Enabled = true;
            #endregion

        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            #region UIComponents
            transactionsBtn.BackColor = Color.WhiteSmoke;
            infoBtn.BackColor = Color.White;
            functionsBtn.BackColor = Color.WhiteSmoke;
            infoTab1.Show();
            infoTab1.BringToFront();
            #endregion



        }
    }
}
