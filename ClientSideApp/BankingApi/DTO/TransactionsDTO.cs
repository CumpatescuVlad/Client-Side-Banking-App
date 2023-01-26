namespace BankingApi.DTO
{
    public class TransactionsDTO
    {
        public TransactionsDTO(List<string>? customerFullName, List<string>? typeOfTransaction, List<string>? accountUsed, List<int>? amount, List<string>? recipient, List<string>? transactionDate)
        {
            CustomerFullName = customerFullName;
            TypeOfTransaction = typeOfTransaction;
            AccountUsed = accountUsed;
            Amount = amount;
            Recipient = recipient;
            TransactionDate = transactionDate;
        }

        public List<string>? CustomerFullName { get; private set; }

        public List<string>? TypeOfTransaction { get; private set; }

        public List<string>? AccountUsed { get; private set; }

        public List<int>? Amount { get; private set; }

        public List<string>? Recipient { get; private set; }

        public List<string>? TransactionDate { get; private set; }


    }
}
