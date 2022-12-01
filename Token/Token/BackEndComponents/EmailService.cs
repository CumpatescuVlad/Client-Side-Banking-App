namespace Token.UnderTheHood
{
    public class EmailService
    {
        private string _email = Temp.ReadFile("CustomerEmail.txt");

        private string _password = Temp.ReadFile("CustomerPassword.txt");

        public string Email { get => _email; }

        public string Password { get => _password; }


    }
}
