namespace BankingApi.DTO
{
    public class OrderDTO
    {
        public OrderDTO(string? customerName, string? typeOfOrder, string? startingDate, string? endingDate, string? transferModel)
        {
            CustomerName = customerName;
            TypeOfOrder = typeOfOrder;
            StartingDate = startingDate;
            EndingDate = endingDate;
            TransferModel = transferModel;
        }

        public string? CustomerName { get; private set; }
        public string? TypeOfOrder { get; private set; }
        public string? StartingDate { get; private set; }
        public string? EndingDate { get; private set; }
        public string? TransferModel { get; private set; }
    }
}
