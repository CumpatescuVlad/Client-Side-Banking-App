using System.ComponentModel.DataAnnotations;

namespace BankingApi.Models
{
    public class TransferModel : TransactionModel
    {
        [Required(ErrorMessage = "SenderBallance Cannot Be null.")]
        public int? SenderBallance { get; set; }

    }
}
