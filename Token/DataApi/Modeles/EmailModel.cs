using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace DataApi.Modeles
{
    public class EmailModel
    {
        [Required(ErrorMessage ="Sender Name cannot be null.")]
        public string? SenderName { get; set; }
        [EmailAddress(ErrorMessage ="The Email adress is not in the correct format.")]
        public string? SenderAdress { get; set; }
        [EmailAddress(ErrorMessage = "The Email adress is not in the correct format.")]
        public string? ReciverAdress { get; set; }
        [Required(ErrorMessage = "Subject cannot be null.")]
        public string? Subject { get; set; }
        [Required(ErrorMessage = "CustomerName cannot be null.")]
        public string? CustomerName { get; set; }
        [EmailAddress(ErrorMessage = "The Email adress is not in the correct format.")]
        public string? AuthentificationEmail { get; set; }
        [Required(ErrorMessage = "AuthentificationPassword cannot be null.")]
        public string? AuthentificationPassword { get; set; }

    }
}
