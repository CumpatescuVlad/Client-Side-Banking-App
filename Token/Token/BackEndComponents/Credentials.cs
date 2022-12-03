using Newtonsoft.Json;

namespace Token.BackEndComponents
{
    public class Credentials
    {
        public bool isMatching(TextBox fullNameBox, TextBox passwordBox)
        {
            CustomerData customerData = JsonConvert.DeserializeObject<CustomerData>(Temp.ReadFile("CustomerData.Json"));

            bool nameIsMatching = fullNameBox.Text == customerData.CustomerFullName;

            bool passwordIsmatching = passwordBox.Text == customerData.CustomerPassword;

            bool credentialsAreCorrect = nameIsMatching is true && passwordIsmatching is true;

            return credentialsAreCorrect;
        }


    }
}
