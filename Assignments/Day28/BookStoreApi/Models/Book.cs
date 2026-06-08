using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Range(1900, 2100)]
        public int PublicationYear { get; set; }

        public int AuthorId { get; set; }

        public Author? Author { get; set; }
    }
}