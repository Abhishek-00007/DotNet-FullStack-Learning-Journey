using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        public int AuthorId { get; set; }

        public Author? Author { get; set; }

        public ICollection<Genre>? Genres { get; set; }
    }
}