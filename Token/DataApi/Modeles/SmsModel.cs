using System.ComponentModel.DataAnnotations;

namespace DataApi.Modeles
{
    public class SmsModel
    {
        [Required]
        public string? CustomerName { get; set; }
        [Required]
        [MaxLength(10,ErrorMessage ="Phone number cannot have more than 10 digits")]
        public string? ReciverPhoneNumber { get; set; }

    }
}
