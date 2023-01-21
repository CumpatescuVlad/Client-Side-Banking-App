namespace BankingApi.Models
{
    public class TransferModel:ModelBase
    {//put atributes

        public int? SenderBallance { get; set; }
        public int? RecipientBallance { get; set; }
    }
}
