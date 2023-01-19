using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataApi.Modeles
{
    public class EmailModel
    {
        [Required]
        public string? SenderName { get; set; }
        [Required]
        public string? SenderAdress { get; set; }
        [Required]
        public string? ReciverAdress { get; set; }
        [Required]
        public string? Subject { get; set; }
        [Required]
        public string? CustomerName { get; set; }
        [Required]
        public string? AuthentificationEmail { get; set; }
        [Required]
        public string? AuthentificationPassword { get; set; }

    }
}
