using ClientSideApp.src;
using Newtonsoft.Json;

namespace ClientSideApp
{
    public partial class LoginTab : UserControl
    {
        private readonly UIBehaviour UI = new();
        CustomerData _customerData = JsonConvert.DeserializeObject<CustomerData>(Temp.ReadTokenFiles("CustomerData.json"));
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
            if (textBox1.Text.Length == 4 && textBox1.Text != _customerData.CustomerPIN)
            {
                MessageBox.Show("Incorrect Pin.");

                UI.ResetLoginTabUI(textBox1, StarOne, StarTwo, StarThree, StarFour);

                return;

            }

            else if (textBox1.Text.Length == 4 && textBox1.Text == _customerData.CustomerPIN)
            {
                overviewTab1.Show();
                overviewTab1.BringToFront();

            }

        }

        private void overviewTab1_Load(object sender, EventArgs e)
        {
            
        }

        private void LoginTab_Load(object sender, EventArgs e)
        {
            searchingLabel.Hide();
            textBox1.Hide();
            overviewTab1.Hide();
        }


    }
}
