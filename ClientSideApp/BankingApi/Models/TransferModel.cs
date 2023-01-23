using System.ComponentModel.DataAnnotations;

namespace BankingApi.Models
{
    public class TransferModel : ModelBase
    {
        //put atributes
        [Required(ErrorMessage = "SenderBallance Cannot Be null.")]
        public int? SenderBallance { get; set; }

        [Required(ErrorMessage = "TypeOfTransaction cannot be null.")]
        public string? TypeOfTransaction { get; set; }

        [Required(ErrorMessage = "AccountIBAN cannot be null.")]
        public string? AccountIBAN { get; set; }

    }
}
