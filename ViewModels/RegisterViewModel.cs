using System.ComponentModel.DataAnnotations;

namespace School.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public required string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password"
        ,

        ErrorMessage = "Password and confirmation password do not match.")]
        public required string ConfirmPassword { get; set; }

    }
}
