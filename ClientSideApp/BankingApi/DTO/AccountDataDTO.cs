namespace BankingApi.DTO
{
    public class AccountDataDTO
    {
        public AccountDataDTO(string? customerName, string? accountNumber, string? accountIBAN, int? balance)
        {
            CustomerName = customerName;
            AccountNumber = accountNumber;
            AccountIBAN = accountIBAN;
            Balance = balance;
        }

        public string? CustomerName { get; private set; }

        public string? AccountNumber { get; private set; }

        public string? AccountIBAN { get; private set; }

        public int? Balance { get; private set; }

    }
}
