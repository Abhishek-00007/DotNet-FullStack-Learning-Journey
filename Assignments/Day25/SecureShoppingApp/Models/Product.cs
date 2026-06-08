using System.ComponentModel.DataAnnotations;

namespace SecureShoppingApp.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Range(1, 100000)]
    public decimal Price { get; set; }
}