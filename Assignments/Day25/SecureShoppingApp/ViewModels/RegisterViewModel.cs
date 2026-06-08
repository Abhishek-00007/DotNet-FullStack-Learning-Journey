using System.ComponentModel.DataAnnotations;

namespace SecureShoppingApp.ViewModels;

public class RegisterViewModel
{
    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [RegularExpression(
        @"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
        ErrorMessage = "Password must contain uppercase, number and special character."
    )]
    public string Password { get; set; } = string.Empty;

    [Required]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = string.Empty;
}
