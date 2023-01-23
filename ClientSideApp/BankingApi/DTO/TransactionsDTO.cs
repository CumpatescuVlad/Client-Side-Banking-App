namespace BankingApi.DTO
{
    public class TransactionsDTO
    {
        public string? CustomerFullName { get;set; }

        public string? TypeOfTransaction { get; set; }

        public string? AccountUsed { get; set; }

        public int? Amount { get; set; }

        public string? Recipient { get; set; }

        public string? TransactionDate { get; set; }


    }
}
