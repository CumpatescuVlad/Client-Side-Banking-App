using System.ComponentModel.DataAnnotations;

namespace BankingApi.Models
{
    public class OrderModel : TransferModel
    {
        [Required(ErrorMessage = "You need to specify a remaning amount.")]
        public int? AmountToRemain { get; set; }

        [Required(ErrorMessage = "Type of order must be standing or sweeping.")]
        public string? TypeOfOrder { get; set; }

        [Required(ErrorMessage = "Starting date is required.")]
        public string? StartingDate { get; set; }

        [Required(ErrorMessage = "Ending date is required.")]
        public string? EndingDate { get; set; }
    }
}
