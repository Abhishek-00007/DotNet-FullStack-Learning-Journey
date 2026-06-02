using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BookStore.Validation
{
    public class IsbnValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object? value,
            ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("ISBN is required.");

            string isbn = value.ToString()!;

            bool valid = Regex.IsMatch(
                isbn,
                @"^(97(8|9))?\d{9}(\d|X)$");

            return valid
                ? ValidationResult.Success!
                : new ValidationResult("Invalid ISBN format.");
        }
    }
}