using ClientSideApp.src;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace ClientSideApp
{
    public partial class FunctionsTab : UserControl
    {
        CustomerData _customerData = JsonConvert.DeserializeObject<CustomerData>(Temp.ReadTokenFiles("CustomerData.json"));
        private readonly SqlConnection connection = new(DataSelection.ConnectionString);
        private readonly ExtractData data = new();
        public FunctionsTab()
        {
            InitializeComponent();
            directDebit.Click += DirectDebit_Click;
            standingOrders.Click += StandingOrders_Click;
            statementlabel.Click += Statementlabel_Click;
            this.MouseEnter += FunctionsTab_MouseEnter;

        }

        private void FunctionsTab_MouseEnter(object? sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(owner.Text))
            {
                owner.Text = data.ReadCreditCard(_customerData.CustomerFullName);
            }

        }

        private void Statementlabel_Click(object? sender, EventArgs e)
        {
            data.ReadAccountData(_customerData.CustomerFullName);
            statementTab1.Show();
            statementTab1.BringToFront();

        }

        private void StandingOrders_Click(object? sender, EventArgs e)
        {
            standingOrderTab1.Show();
            standingOrderTab1.BringToFront();
        }

        private void DirectDebit_Click(object? sender, EventArgs e)
        {
            dirtectDebitTab1.Show();
            dirtectDebitTab1.BringToFront();
        }

        private void FunctionsTab_Load(object sender, EventArgs e)
        {
            standingOrderTab1.Hide();
            dirtectDebitTab1.Hide();
            statementTab1.Hide();

        }

        private void standingOrderTab1_Load(object sender, EventArgs e)
        {

        }


    }
}
