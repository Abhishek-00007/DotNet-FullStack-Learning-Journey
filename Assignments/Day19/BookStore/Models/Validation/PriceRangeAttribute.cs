using System.ComponentModel.DataAnnotations;

namespace BookStore.Validation
{
    public class PriceRangeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object? value,
            ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Price is required.");

            decimal price = (decimal)value;

            if (price < 1 || price > 10000)
            {
                return new ValidationResult(
                    "Price must be between 1 and 10000.");
            }

            return ValidationResult.Success!;
        }
    }
}