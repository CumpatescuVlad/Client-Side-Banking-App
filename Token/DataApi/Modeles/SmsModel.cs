using System.ComponentModel.DataAnnotations;

namespace DataApi.Modeles
{
    public class SmsModel
    {
        [Required(ErrorMessage = "CustomerName cannot be null.")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "Phone number was not in the correct format.")]
        [MaxLength(10,ErrorMessage ="Phone number cannot have more than 10 digits")]
        public string? ReciverPhoneNumber { get; set; }

    }
}
