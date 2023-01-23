using System.ComponentModel.DataAnnotations;

namespace BankingApi.Models
{
    public class ModelBase
    {
        [Required(ErrorMessage ="Customer Name cannot be null.")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "Recipient Name cannot be null.")]
        public string? Recipient { get; set; }

        [Required(ErrorMessage ="Ammount cannot be null or 0.")]
        
        public int? Amount { get; set; }

        [Required(ErrorMessage = "Date And Time cannot be null.")]
        public string? DateAndTime { get; set; }
    }
}
