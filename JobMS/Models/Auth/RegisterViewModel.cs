using System.ComponentModel.DataAnnotations;

namespace JobMS.Models.Auth
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Password does not match")]
        //public string ConfirmPassword { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}