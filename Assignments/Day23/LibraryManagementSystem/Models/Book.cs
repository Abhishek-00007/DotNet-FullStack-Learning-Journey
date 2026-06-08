using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}