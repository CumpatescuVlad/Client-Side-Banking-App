namespace BankingApi.Models
{
    public class ModelBase
    {
        public string? Sender { get; set; }

        public string? AccountUsed { get; set; }

        public string? Recipient { get; set; }

        public int? Amount { get; set; }

        public int? DateAndTime { get; set; }
    }
}
