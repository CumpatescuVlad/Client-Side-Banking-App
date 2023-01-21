using ClientSideApp.src;
using Newtonsoft.Json;

namespace ClientSideApp
{
    public partial class OverviewTab : UserControl
    {
        private readonly ExtractData customerData = new();
        CustomerData _customerData = JsonConvert.DeserializeObject<CustomerData>(Temp.ReadTokenFiles("CustomerData.json"));

        public OverviewTab()
        {
            InitializeComponent();
            richTextBox1.Click += RichTextBox1_Click;
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            this.MouseEnter += OverviewTab_MouseEnter;

        }

        private void OverviewTab_MouseEnter(object? sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox1.Text))
            {
                #region ReadAccountData
                greetMessage.Text = $"Hello {_customerData.CustomerFullName}";
                richTextBox1.Text = customerData.ReadAccountData(_customerData.CustomerFullName);
                #endregion

            }

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
            button2.Hide();
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
            button2.Show();
            #endregion

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = customerData.ReadAccountData(_customerData.CustomerFullName);
        }
    }
}
