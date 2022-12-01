namespace ClientSideApp;

public class UIBehaviour
{

    public void ChangeStarColor(Label starOne, Label starTwo, Label starThree, Label starFour)
    {

        int count = int.Parse(Temp.ReadFile("Count.txt"));

        count++;

        Temp.CreateFile("Count.txt", $"{count}");


        switch (int.Parse(Temp.ReadFile("Count.txt")))
        {
            case 1:
                starOne.ForeColor = Color.Black;

                break;
            case 2:
                starTwo.ForeColor = Color.Black;

                break;
            case 3:
                starThree.ForeColor = Color.Black;

                break;
            case 4:
                starFour.ForeColor = Color.Black;

                break;

        }


    }

    public void ResetLoginTabUI(TextBox textBox, Label starOne, Label starTwo, Label starThree, Label starFour)
    {
        textBox.Clear();
        Temp.CreateFile("Count.txt", $"{0}");
        starOne.ForeColor = Color.DarkGray;
        starTwo.ForeColor = Color.DarkGray;
        starThree.ForeColor = Color.DarkGray;
        starFour.ForeColor = Color.DarkGray;
    }

}

