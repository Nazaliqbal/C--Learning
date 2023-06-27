using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace WebAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]  
        public string? FullName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

         
        [Required]
        [DataType(DataType.Password)]

        public string? Password { get; set; } 
        public string? PhoneNumber { get; set; }
    }
}
