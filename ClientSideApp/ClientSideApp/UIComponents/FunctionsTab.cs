using Microsoft.Data.SqlClient;

namespace ClientSideApp
{
    public partial class FunctionsTab : UserControl
    {
        private readonly SqlConnection connection = new SqlConnection(DataSelection.ConnectionString);
        public FunctionsTab()
        {
            InitializeComponent();
            directDebit.Click += DirectDebit_Click;
            standingOrders.Click += StandingOrders_Click;
            statementlabel.Click += Statementlabel_Click;


        }

        private void Statementlabel_Click(object? sender, EventArgs e)
        {
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

            owner.Text = ReadCreditCard(Temp.ReadFile("CustomerFullName.txt"));

            standingOrderTab1.Hide();
            dirtectDebitTab1.Hide();
            statementTab1.Hide();

        }

        private void standingOrderTab1_Load(object sender, EventArgs e)
        {

        }

        private string ReadCreditCard(string customerName)
        {
            string creditCardData = null;

            var readCreditCardDataCommand = new SqlCommand(DataSelection.SelectData("CustomerName,CreditCardNumber", "CreditCard", "CustomerName", customerName), connection);

            connection.Open();

            var reader = readCreditCardDataCommand.ExecuteReader();

            while (reader.Read())
            {
                creditCardData = $"{reader.GetValue(0)} \n{reader.GetValue(1)}";
            }
            connection.Close();

            return creditCardData;
        }
    }
}
