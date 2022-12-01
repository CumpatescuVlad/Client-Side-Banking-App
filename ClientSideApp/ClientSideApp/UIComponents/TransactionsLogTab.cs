namespace ClientSideApp
{
    public partial class TransactionsLogTab : UserControl
    {
        private readonly ExtractData extractdata = new();
        public TransactionsLogTab()
        {
            InitializeComponent();

        }

        private void TransactionsLogTab_Load(object sender, EventArgs e)
        {

            if (this.Visible is true)
            {
                richTextBox1.Text = extractdata.ReadCustomerTransactions(Temp.ReadFile("CustomerFullName.txt"));

            }

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
