using System.ComponentModel.DataAnnotations;
using BookStore.Validation;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        [Required]
        [IsbnValidation]
        public string ISBN { get; set; } = string.Empty;

        [PriceRange]
        public decimal Price { get; set; }
    }
}