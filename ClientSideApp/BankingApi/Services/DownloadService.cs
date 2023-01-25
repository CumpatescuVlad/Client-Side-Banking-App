using BankingApi.src;
using Microsoft.AspNetCore.Mvc;


namespace BankingApi.Services
{
    public class DownloadService : IDownloadService
    {
        ILogger<DownloadService> _logger;

        public DownloadService(ILogger<DownloadService> logger)
        {
            _logger = logger;
        }

        public byte[] DownloadWordStatement()
        {
            var wordStatenment =$@"{Environment.CurrentDirectory}\Statements\WordStatements\Statement.doc";

            try
            {
                byte[] wordBytes = File.ReadAllBytes(wordStatenment);

                return wordBytes;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return null;
            }

        }

        public byte[] DownloadPdfStatement()
        {
            var pdfStatement = $@"{Environment.CurrentDirectory}\Statements\PdfStatements\Statement.pdf";

            try
            {
                byte[] pdfBytes = File.ReadAllBytes(pdfStatement);

                return pdfBytes;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return null;
            }

        }


    }
}
