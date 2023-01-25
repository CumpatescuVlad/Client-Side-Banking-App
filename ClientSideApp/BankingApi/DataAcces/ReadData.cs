using BankingApi.Config;
using BankingApi.DTO;
using BankingApi.src;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Transactions;

namespace BankingApi.DataAcces
{
    public class ReadData : IReadData
    {
        private readonly ConfigurationModel _configModel;

        public ReadData(IOptions<ConfigurationModel> configModel)
        {
            _configModel = configModel.Value;
        }

        public AccountDataDTO ReadAccountInfo(string customerName)
        {
            var _connection = new SqlConnection(_configModel.ConnectionString);
            var accountCommand = new SqlCommand(QuerryStrings.SelectAccountData(customerName), _connection);
            _connection.Open();
            var reader = accountCommand.ExecuteReader();

            reader.Read();
            var accountData = new AccountDataDTO(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            reader.Close();

            _connection.Close();
            return accountData;
        }

        public TransactionsDTO ReadAccountTransactions(string customerName,string status)
        {
            TransactionsDTO? transactions = null;
            var customerNameList = new List<string>();
            var transactionTypeList = new List<string>();
            var accountUsedList = new List<string>();
            var amountList = new List<int>();
            var recipientNameList = new List<string>();
            var transactionDateList = new List<string>();
            var _connection = new SqlConnection(_configModel.ConnectionString);
            var transactionCommand = new SqlCommand(QuerryStrings.SelectAccountTransactions(customerName,status), _connection);

            _connection.Open();
            if (status == "Income")
            {
                var reader = transactionCommand.ExecuteReader();

                while (reader.Read())
                {
                    customerNameList.Add(reader.GetString(0));
                    transactionTypeList.Add(reader.GetString(1));
                    accountUsedList.Add("You Recived");
                    amountList.Add(reader.GetInt32(2));
                    recipientNameList.Add(reader.GetString(3));
                    transactionDateList.Add(reader.GetString(4));

                    transactions = new TransactionsDTO(customerNameList, transactionTypeList, accountUsedList, amountList, recipientNameList, transactionDateList);

                }

            }
            else if (status == "Outcome")
            {
                var reader = transactionCommand.ExecuteReader();

                while (reader.Read())
                {
                    customerNameList.Add("You Transfered");
                    transactionTypeList.Add(reader.GetString(0));
                    accountUsedList.Add(reader.GetString(1));
                    amountList.Add(reader.GetInt32(2));
                    recipientNameList.Add(reader.GetString(3));
                    transactionDateList.Add(reader.GetString(4));

                    transactions = new TransactionsDTO(customerNameList, transactionTypeList, accountUsedList, amountList, recipientNameList, transactionDateList);

                }

            }
            _connection.Close();


            return transactions;
        }

        public string ReadStatementTransactions(string customerName, string status)
        {
            var _connection = new SqlConnection(_configModel.ConnectionString);
            var transactionCommand = new SqlCommand(QuerryStrings.SelectAccountTransactions(customerName, status), _connection);
            string? transactions = null;
            _connection.Open();

            if (status == "Income")
            {
                var reader = transactionCommand.ExecuteReader();

                while (reader.Read())
                {
                    transactions = $"{reader.GetString(0)} Transfered You:{reader.GetInt32(3)} On {reader.GetString(4)}";

                }

            }
            else if (status == "Outcome")
            {
                var reader = transactionCommand.ExecuteReader();

                while (reader.Read())
                {
                    transactions = $"{"You Transfered"}:{reader.GetInt32(2)} To {reader.GetString(3)} on {reader.GetString(4)}";

                }

            }
            _connection.Close();

            return transactions;
        }

        public CompanyDTO ReadCompanyNames()
        {
            CompanyDTO? companyNames = null;
            var nameList = new List<string>();
            var serviceList = new List<string>();
            var IBANList = new List<string>();
            var connection = new SqlConnection(_configModel.ConnectionString);
            var readCompaniesCommand = new SqlCommand(QuerryStrings.SelectCompanies(), connection);

            connection.Open();
            var reader = readCompaniesCommand.ExecuteReader();

            while (reader.Read())
            {
                nameList.Add(reader.GetString(0));
                serviceList.Add(reader.GetString(1));
                IBANList.Add(reader.GetString(2));

                companyNames = new CompanyDTO(nameList, serviceList, IBANList);

            }
            connection.Close();

            return companyNames;

        }
    }
}
