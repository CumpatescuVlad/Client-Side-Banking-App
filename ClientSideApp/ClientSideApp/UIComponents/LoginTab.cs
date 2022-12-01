namespace ClientSideApp
{
    public partial class LoginTab : UserControl
    {
        private readonly UIBehaviour UI = new();
        private readonly ExtractData customerData = new();

        public LoginTab()
        {
            InitializeComponent();

        }

        #region KeyPad
        private void button1_Click(object sender, EventArgs e)
        {
            UI.ChangeStarColor(StarOne, StarTwo, StarThree, StarFour);

            textBox1.Text += "1";
        }

        private void KeyTwo_Click(object sender, EventArgs e)
        {
            UI.ChangeStarColor(StarOne, StarTwo, StarThree, StarFour);

            textBox1.Text += "2";
        }

        private void KeyThree_Click(object sender, EventArgs e)
        {
            UI.ChangeStarColor(StarOne, StarTwo, StarThree, StarFour);

            textBox1.Text += "3";
        }

        private void KeyFour_Click(object sender, EventArgs e)
        {
            UI.ChangeStarColor(StarOne, StarTwo, StarThree, StarFour);

            textBox1.Text += "4";
        }

        private void KeyFive_Click(object sender, EventArgs e)
        {
            UI.ChangeStarColor(StarOne, StarTwo, StarThree, StarFour);

            textBox1.Text += "5";
        }

        private void KeySix_Click(object sender, EventArgs e)
        {
            UI.ChangeStarColor(StarOne, StarTwo, StarThree, StarFour);

            textBox1.Text += "6";

        }

        private void KeySeven_Click(object sender, EventArgs e)
        {
            UI.ChangeStarColor(StarOne, StarTwo, StarThree, StarFour);

            textBox1.Text += "7";
        }

        private void KeyEight_Click(object sender, EventArgs e)
        {
            UI.ChangeStarColor(StarOne, StarTwo, StarThree, StarFour);

            textBox1.Text += "8";

        }

        private void KeyNine_Click(object sender, EventArgs e)
        {
            UI.ChangeStarColor(StarOne, StarTwo, StarThree, StarFour);

            textBox1.Text += "9";
        }

        private void KeyZero_Click(object sender, EventArgs e)
        {
            UI.ChangeStarColor(StarOne, StarTwo, StarThree, StarFour);

            textBox1.Text += "0";
        }
        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (textBox1.Text.Length == 4)
            //{
            //    customerData.ReadCustomerPIN(textBox1.Text);
            //}

            if (textBox1.Text.Length == 4 && customerData.ReadCustomerPIN(textBox1.Text) is null)
            {
                MessageBox.Show("Customer Not Found!");

                UI.ResetLoginTabUI(textBox1, StarOne, StarTwo, StarThree, StarFour);

                return;
            }

            else if (textBox1.Text.Length == 4 && textBox1.Text != customerData.ReadCustomerPIN(textBox1.Text))
            {
                MessageBox.Show("Incorrect Pin.");

                UI.ResetLoginTabUI(textBox1, StarOne, StarTwo, StarThree, StarFour);

                return;

            }

            else if (textBox1.Text.Length == 4 && textBox1.Text == customerData.ReadCustomerPIN(textBox1.Text))
            {
                //Temp.CreateFile("CustomerFullName.txt", customerData.ReadCustomerNameByPin(textBox1.Text));

                overviewTab1.Show();
                overviewTab1.BringToFront();

            }

        }

        private void overviewTab1_Load(object sender, EventArgs e)
        {
            if (File.Exists($"{Temp.FolderPath}/CustomerAppPIN.txt") is false && File.Exists($"{Temp.FolderPath}/CustomerFullName.txt") is false)
            {
                activateApp1.Show();
                activateApp1.BringToFront();

            }
            else
            {
                customerData.ReadAccountData(Temp.ReadFile("CustomerFullName.txt"));

                activateApp1.Hide();

            }
        }

        private void LoginTab_Load(object sender, EventArgs e)
        {

            searchingLabel.Hide();
            textBox1.Hide();
            overviewTab1.Hide();
        }


    }
}
