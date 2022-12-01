namespace ClientSideApp
{
    public partial class StatementTab : UserControl
    {
        private readonly Statements statement = new();

        public StatementTab()
        {
            InitializeComponent();
        }

        private void StatementTab_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Box.IsNumber(fromDateBox) is false || Box.IsNumber(toDateBox) is false)
            {
                return;
            }
            else if (Box.IsEmpty(fromDateBox) || Box.IsEmpty(toDateBox))
            {
                return;
            }

            if (formatBox.Text == "Word")
            {
                statement.GenerateWordStatement(fromDateBox, toDateBox);

                File.Replace($@"{Temp.FolderPath}\OriginalStatement.docx", $@"{Temp.FolderPath}\Statement.docx", $@"{Temp.FolderPath}\StatementBck.docx");

            }
            else if (formatBox.Text == "Csv")
            {
                statement.GenerateCsvStatement(fromDateBox, toDateBox);

            }
            else if (formatBox.Text == "Pdf")
            {
                statement.GeneratePdfStatement(fromDateBox.Text, toDateBox.Text);

                File.Replace($@"{Temp.FolderPath}\OriginalStatement.pdf", $@"{Temp.FolderPath}\Statement.pdf", $@"{Temp.FolderPath}\StatementBck.pdf");

            }
            MessageBox.Show("Statement Generated.");

            //Generate Statement Here
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
