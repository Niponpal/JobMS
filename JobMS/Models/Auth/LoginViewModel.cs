using System.ComponentModel.DataAnnotations;

namespace JobMS.Models.Auth
{
    public class LoginViewModel
    {
        [Required, EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
