using System.ComponentModel.DataAnnotations;

namespace RegistrationSystem.Models
{
    public class ConfirmPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            var user =
                (UserRegistration)validationContext.ObjectInstance;

            if (user.Password == user.ConfirmPassword)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(
                "Passwords do not match");
        }
    }
}