using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class RegisterView
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",
            ErrorMessage="Passwords do not match")]

        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression("^(Admin|Manager|User|Guest)$", ErrorMessage = "Invalid role specified.")]
        public string Role { get; set;}
    }
}
