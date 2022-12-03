namespace ClientSideApp.UIComponents
{
    public partial class AppActivation : Form
    {
        public AppActivation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
