namespace ClientSideApp
{
    public static class Box
    {
        public static bool IsEmpty(TextBox textBox)
        {
            bool isEmpty = String.IsNullOrEmpty(textBox.Text);

            if (isEmpty is true)
            {
                MessageBox.Show("Please Introduce A Value.");
                textBox.Clear();
            }

            return isEmpty;

        }

        public static bool HasText(TextBox textBox)
        {
            bool hasText = textBox.Text.Length > 0;

            return hasText;
        }
        public static bool IsNumber(TextBox textBox)
        {
            bool isNumber = textBox.Text.StartsWith("1") || textBox.Text.StartsWith("2") || textBox.Text.StartsWith("3")
                           || textBox.Text.StartsWith("4") || textBox.Text.StartsWith("5") || textBox.Text.StartsWith("6")
                           || textBox.Text.StartsWith("7") || textBox.Text.StartsWith("8") || textBox.Text.StartsWith("9")
                           || textBox.Text.StartsWith("0");

            if (isNumber is false)
            {
                MessageBox.Show("Only Numbers Are Allowed!");
                textBox.Clear();
            }

            return isNumber;
        }
    }
}
