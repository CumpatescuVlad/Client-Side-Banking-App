namespace Token.UnderTheHood
{
    public class Credentials
    {

        public bool isMatching(TextBox fullNameBox, TextBox passwordBox)
        {

            bool nameIsMatching = fullNameBox.Text == Temp.ReadFile("CustomerFullName.txt");

            bool passwordIsmatching = passwordBox.Text == Temp.ReadFile("CustomerPassword.txt");

            bool credentialsAreCorrect = nameIsMatching is true && passwordIsmatching is true;

            return credentialsAreCorrect;
        }


    }
}
