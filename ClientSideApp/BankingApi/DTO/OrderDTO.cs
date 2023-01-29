namespace BankingApi.DTO
{
    public class OrderDTO
    {
        public OrderDTO(string? customerName, string? typeOfOrder, int? amountToRemain, string? startingDate, string? endingDate, string? transferModel)
        {
            CustomerName = customerName;
            TypeOfOrder = typeOfOrder;
            StartingDate = startingDate;
            EndingDate = endingDate;
            TransferModel = transferModel;
            AmountToRemain = amountToRemain;
        }

        public string? CustomerName { get; private set; }
        public string? TypeOfOrder { get; private set; }
        public int? AmountToRemain { get; private set; }
        public string? StartingDate { get; private set; }
        public string? EndingDate { get; private set; }
        public string? TransferModel { get; private set; }
    }
}
