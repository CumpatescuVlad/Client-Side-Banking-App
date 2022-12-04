using ClientSideApp.src;
using Newtonsoft.Json;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment;

namespace ClientSideApp
{
    public class Statements
    {
        private readonly Random random = new();
        private readonly ExtractData data = new();
        private readonly CustomerData customerData = JsonConvert.DeserializeObject<CustomerData>(Temp.ReadTokenFiles("CustomerData.json"));


        public void GenerateWordStatement(TextBox startingDate, TextBox endingDate)
        {
            
            FileStream wordOutputFile = new(Path.GetFullPath(@$"{Temp.FolderPath}\OriginalStatement.docx"), FileMode.Create, FileAccess.ReadWrite);
            AccountData accountData = JsonConvert.DeserializeObject<AccountData>(Temp.ReadFile("AccountData.json"));

            #region ParagraphSettings
            WordDocument statement = new WordDocument();
            IWSection content = statement.AddSection();
            IWParagraph title = content.AddParagraph();
            IWParagraph leftColum = content.AddParagraph();
            IWParagraph footer = content.AddParagraph();


            title.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            WParagraphStyle style = statement.Styles.FindByName("Normal") as WParagraphStyle;
            style.CharacterFormat.FontName = "Arial";
            style.CharacterFormat.FontSize = 10;
            style.CharacterFormat.Bold = true;
            title.ApplyStyle("Normal");

            #endregion

            title.AppendText($"\n\n\n");

            title.AppendText($"EXTRAS DE CONT NR.{random.Next(1, 10)} din data de  {DateTime.Now}\n pe perioada: {startingDate.Text} - {endingDate.Text}\n");

            leftColum.AppendText("\n\n\n");

            leftColum.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;

            leftColum.AppendText($"NR. Cont:{accountData.AccountNumber}\nIBAN:{accountData.AccountIBAN}\nProduse Valuta:RON\nTitular:{customerData.CustomerFullName}");

            leftColum.AppendText($"\tCIC:{4563523}\tCNP/CUI:{3452353673}\nTip Produs:Cont curent {accountData.AccountName}\n");

            leftColum.AppendText($"Total tranzactii finalizate pana la {DateTime.Now}\n\n\n");

            leftColum.AppendText(data.ReadCustomerTransactions(customerData.CustomerFullName));

            leftColum.AppendText($"Sold Disponibil  la :\t\t\t{DateTime.Now}\t\t\t{accountData.Balance} LEI\n");

            footer.AppendText("\n\n\n");

            footer.AppendText("PREZENTUL DOCUMENT ESTE ELIBERAT DE O BANCA  SI ARE VALOARE DE ORIGINAL FIIND VALABIL   FARA SEMNATURA SI STAMPILA.\n");

            footer.AppendText("Soldul disponibil al zilei bancare inscris pe extrasul de cont reflecta situatia sumelor inregistrate  in contul curent in momentul editarii extrasului de cont, in functie de obligatiile de plataale  titularului de cont initiate sau evidentiate pana la momentul editarii extrasului de cont.");

            statement.Save(wordOutputFile, FormatType.Docx);

            statement.Close();

            wordOutputFile.Close();

            wordOutputFile.Dispose();


        }
        public void GenerateCsvStatement(TextBox startingDate, TextBox endingDate)
        {
            Temp.CreateFile("Statement.csv",
                $"Valabil{startingDate} -- {endingDate} \n\n\n{data.ReadCustomerTransactions(customerData.CustomerFullName)}");

        }

        public void GeneratePdfStatement(string startingDate, string endingDate)
        {
            FileStream pdfOutputFile = new(Path.GetFullPath(@$"{Temp.FolderPath}\OriginalStatement.pdf"), FileMode.Create, FileAccess.ReadWrite);

            #region Template Creation
            PdfDocument statment = new PdfDocument();
            PdfPage page = statment.Pages.Add();
            PdfGraphics graphic = page.Graphics;
            PdfBrush brush = new PdfSolidBrush(Color.Black);
            PdfFont normalFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            var blodFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14, PdfFontStyle.Bold);

            #endregion

            graphic.DrawString(PdfStatementTitle(startingDate, endingDate), blodFont, brush, new PointF(20, 20));

            graphic.DrawString(PdfStatementContent(), normalFont, brush, new PointF(20, 20));

            statment.Save(pdfOutputFile);

            statment.Close(true);

            statment.Dispose();

            pdfOutputFile.Dispose();

        }


        public string PdfStatementContent()
        {
            AccountData accountData = JsonConvert.DeserializeObject<AccountData>(Temp.ReadFile("AccountData.json"));

            string content = "\n\n\n";

            content += "\n\n\n";

            content += $"NR. Cont:{accountData.AccountNumber}\nIBAN:{accountData.AccountIBAN}\nProduse Valuta:RON\nTitular:{customerData.CustomerFullName}";

            content += $"\tCIC:{4563523}\tCNP/CUI:{3452353673}\nTip Produs:Cont curent {accountData.AccountName}\n\n\n";

            content += $"Total tranzactii finalizate pana la: {DateTime.Now}\n";

            content += data.ReadCustomerTransactions(customerData.CustomerFullName);

            content += $"\n\n\nSold Disponibil  la :\t\t\t{DateTime.Now}\t\t\t{accountData.Balance} LEI\n";

            content += "\n\n\n";

            content += "PREZENTUL DOCUMENT ESTE ELIBERAT DE O BANCA  SI ARE VALOARE DE ORIGINAL FIIND VALABIL   FARA SEMNATURA SI STAMPILA.\n\n";

            content += @"Soldul disponibil al zilei bancare inscris pe extrasul de cont reflecta situatia sumelor inregistrate  in 
                       contul curent in momentul editarii extrasului de cont, in functie de obligatiile de plataale  titularului de 
                       cont initiate sau evidentiate pana la momentul editarii extrasului de cont.";

            return content;
        }

        public string PdfStatementTitle(string startingDate, string endingDate) => $"EXTRAS DE CONT NR.{random.Next(1, 10)} din data de  {DateTime.Now} \n\t\t\t\t\t\t\tpe perioada: {startingDate} - {endingDate}\n";


    }

}



