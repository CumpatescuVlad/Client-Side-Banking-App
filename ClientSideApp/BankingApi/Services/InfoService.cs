using BankingApi.DataAcces;
using BankingApi.Models;
using BankingApi.src;
using Newtonsoft.Json;
using System.Net;

namespace BankingApi.Services
{
    public class InfoService : IInfoService
    {
        private readonly IReadData _readData;
        private readonly IGenerateStatements _generateStatements;
        private readonly IDownloadService _downloadService;
        public InfoService(IReadData readData, IGenerateStatements generateStatements, IDownloadService downloadService)
        {
            _readData = readData;
            _generateStatements = generateStatements;
            _downloadService = downloadService;
        }

        public string GetAccountInfo(string customerName)
        {
            return JsonConvert.SerializeObject(_readData.ReadAccountInfo(customerName));
        }

        public string GetCompaniesNames()
        {
            return JsonConvert.SerializeObject(_readData.ReadCompanyNames());
        }

        public byte[] GetWordStatement(StatementModel statementModel)
        {
            if (_generateStatements.GenerateWordStatement(statementModel, _readData.ReadStatementTransactions(statementModel.CustomerName, "Income"), _readData.ReadStatementTransactions(statementModel.CustomerName, "Outcome")) is HttpStatusCode.Created)
            {
                return _downloadService.DownloadWordStatement();
            }
            else
            {
                return null;
            }

        }

        public byte[] GetPdfStatement(StatementModel statementModel)
        {
            if (_generateStatements.GeneratePdfStatement(statementModel, _readData.ReadStatementTransactions(statementModel.CustomerName, "Income"), _readData.ReadStatementTransactions(statementModel.CustomerName, "Outcome")) is HttpStatusCode.Created)
            {
                return _downloadService.DownloadPdfStatement();
            }
            else
            {
                return null;
            }

        }


    }
}
