namespace Token.UnderTheHood
{
    public static class Errors
    {
        public static bool BoxIsEmpty(string imput)
        {
            bool isEmpty = string.IsNullOrEmpty(imput);

            if (isEmpty is true)
            {
                MessageBox.Show("Please Introduce A Value!");
            }

            return isEmpty;
        }
        public static bool IsNumber(TextBox textBox)
        {
            bool isNumber = textBox.Text.Contains('1') || textBox.Text.Contains('2') || textBox.Text.Contains('3')
                || textBox.Text.Contains('4') || textBox.Text.Contains('5') || textBox.Text.Contains('6')
                || textBox.Text.Contains('7') || textBox.Text.Contains('8') || textBox.Text.Contains('9')
                || textBox.Text.Contains('0');

            return isNumber;
        }
        public static bool HasFiveOrMoreNumbers(TextBox textBox) => textBox.Text.Length >= 5;

    }
}
