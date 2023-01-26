using BankingApi.Models;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Net;

namespace BankingApi.src
{
    public class GenerateStatements : IGenerateStatements
    {
        private readonly Random random = new();
        private readonly ILogger<GenerateStatements> _logger;
       
        public GenerateStatements(ILogger<GenerateStatements> logger)
        {
            _logger = logger;
        }

        public HttpStatusCode GenerateWordStatement(StatementModel statementModel, string incomeTransactions, string outcomeTransactions)
        {
            FileStream wordOutputFile = new(Path.GetFullPath(@$"{Environment.CurrentDirectory}\Statements\WordStatements\Statement.doc"), FileMode.Create, FileAccess.ReadWrite);


            var statement = new WordDocument();
            IWSection content = statement.AddSection();
            IWParagraph title = content.AddParagraph();
            IWParagraph leftColum = content.AddParagraph();
            IWParagraph footer = content.AddParagraph();


            title.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            WParagraphStyle? style = statement.Styles.FindByName("Normal") as WParagraphStyle;
            style.CharacterFormat.FontName = "Arial";
            style.CharacterFormat.FontSize = 10;
            style.CharacterFormat.Bold = true;
            title.ApplyStyle("Normal");

            title.AppendText($"\n\n\n");

            title.AppendText($"EXTRAS DE CONT NR.{random.Next(1, 10)} din data de  {DateTime.Now}\n pe perioada: {DateTime.UtcNow} - {DateTime.Now.AddDays(3)}\n\n\n\n");

            leftColum.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;

            leftColum.AppendText($"IBAN:{statementModel.AccountIBAN}\nProduse Valuta:RON\nTitular:{statementModel.CustomerName} \tCIC:{4563523}\tCNP/CUI:{3452353673}\nTip Produs:Cont curent {statementModel.CurrentAccount}\n");

            leftColum.AppendText($"Total tranzactii finalizate pana la {DateTime.Now}\n\n\n{incomeTransactions}\n{outcomeTransactions}\n\n\n");

            footer.AppendText("PREZENTUL DOCUMENT ESTE ELIBERAT DE O BANCA  SI ARE VALOARE DE ORIGINAL FIIND VALABIL   FARA SEMNATURA SI STAMPILA.\n");

            footer.AppendText("Soldul disponibil al zilei bancare inscris pe extrasul de cont reflecta situatia sumelor inregistrate  in contul curent in momentul editarii extrasului de cont, in functie de obligatiile de plataale  titularului de cont initiate sau evidentiate pana la momentul editarii extrasului de cont.");

            try
            {
                statement.Save(wordOutputFile, FormatType.Doc);
                statement.Close();
                wordOutputFile.Close();
                wordOutputFile.Dispose();
                statement.Dispose();
                return HttpStatusCode.Created;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return HttpStatusCode.InternalServerError;
            }

        }

        public HttpStatusCode GeneratePdfStatement(StatementModel statementModel, string incomeTransactions, string outcomeTransactions)
        {
            FileStream pdfOutputFile = new(Path.GetFullPath(@$"{Environment.CurrentDirectory}\Statements\PdfStatements\Statement.pdf"), FileMode.Create, FileAccess.ReadWrite);

            var statment = new PdfDocument();
            PdfPage page = statment.Pages.Add();
            PdfGraphics graphic = page.Graphics;
            PdfBrush brush = new PdfSolidBrush(Color.Black);
            PdfFont normalFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            var boldFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14, PdfFontStyle.Bold);

            graphic.DrawString($"EXTRAS DE CONT NR.{random.Next(1, 10)} din data de  {DateTime.Now} \n\t\t\t\t\t\t\tpe perioada: {DateTime.UtcNow} - {DateTime.UtcNow.AddDays(3)}\n", boldFont, brush, new PointF(20, 20));

            graphic.DrawString(PdfStatementContent(statementModel, incomeTransactions, outcomeTransactions), normalFont, brush, new PointF(20, 20));

            try
            {
                statment.Save(pdfOutputFile);

                statment.Close(true);

                statment.Dispose();

                pdfOutputFile.Dispose();

                return HttpStatusCode.Created;

            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return HttpStatusCode.InternalServerError;
            }

        }
        private static string PdfStatementContent(StatementModel statementModel, string incomeTransactions, string outcomeTransactions)
        {
            string content = "\n\n\n\n\n\n";

            content += $"IBAN:{statementModel.AccountIBAN}\nProduse Valuta:RON\nTitular:{statementModel.CustomerName}\tCIC:{4563523}\tCNP/CUI:{3452353673}\nTip Produs:Cont curent {statementModel.CurrentAccount}\n\n\n";

            content += $"Total tranzactii finalizate pana la: {DateTime.Now}\n{incomeTransactions}\n{outcomeTransactions}\n\n\nPREZENTUL DOCUMENT ESTE ELIBERAT DE O BANCA  SI ARE VALOARE DE ORIGINAL FIIND VALABIL   FARA SEMNATURA SI STAMPILA.\n\n";

            content += @"Soldul disponibil al zilei bancare inscris pe extrasul de cont reflecta situatia sumelor inregistrate  in 
                       contul curent in momentul editarii extrasului de cont, in functie de obligatiile de plataale  titularului de 
                       cont initiate sau evidentiate pana la momentul editarii extrasului de cont.";

            return content;
        }

    }
}
