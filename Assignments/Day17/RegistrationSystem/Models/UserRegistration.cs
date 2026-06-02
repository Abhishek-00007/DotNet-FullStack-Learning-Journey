using System.ComponentModel.DataAnnotations;

namespace RegistrationSystem.Models
{
    public class UserRegistration
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [ConfirmPassword]
        public string ConfirmPassword { get; set; }
    }
}