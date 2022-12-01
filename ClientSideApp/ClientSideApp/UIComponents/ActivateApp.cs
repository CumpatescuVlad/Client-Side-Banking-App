namespace ClientSideApp
{
    public partial class ActivateApp : UserControl
    {
        public ActivateApp()
        {
            InitializeComponent();
        }

        private void doneBTn_Click(object sender, EventArgs e)
        {
            if (File.Exists($"{Temp.FolderPath}/CustomerAppPIN.txt") is false)
            {
                MessageBox.Show("To Proceed Further Please Open Token \n And Activate Your App.");

                return;
            }
            else if (File.Exists($"{Temp.FolderPath}/CustomerAppPIN.txt") is true)
            {
                this.Hide();
            }
        }
    }
}
