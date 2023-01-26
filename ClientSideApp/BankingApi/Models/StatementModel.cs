using System.ComponentModel.DataAnnotations;

namespace BankingApi.Models
{
    public class StatementModel
    {
        [Required(ErrorMessage = "CustomerName cannot be null.")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "AccountIBAN cannot be null.")]
        public string? AccountIBAN { get; set; }

        [Required(ErrorMessage = "CurrentAccount cannot be null.")]
        public string? CurrentAccount { get; set; }

    }
}
