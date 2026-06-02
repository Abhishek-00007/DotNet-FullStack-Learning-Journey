using BookStore.Models;

namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private static List<Book> books = new()
        {
            new Book
            {
                Id = 1,
                Title = "Clean Code",
                Author = "Robert Martin",
                ISBN = "9780132350884",
                Price = 500
            },

            new Book
            {
                Id = 2,
                Title = "Design Patterns",
                Author = "GoF",
                ISBN = "9780201633610",
                Price = 800
            }
        };

        public List<Book> GetAll()
        {
            return books;
        }

        public Book? GetById(int id)
        {
            return books.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Book book)
        {
            book.Id = books.Max(x => x.Id) + 1;
            books.Add(book);
        }

        public void Update(Book book)
        {
            var existing = GetById(book.Id);

            if (existing == null)
                return;

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.ISBN = book.ISBN;
            existing.Price = book.Price;
        }

        public void Delete(int id)
        {
            var book = GetById(id);

            if (book != null)
                books.Remove(book);
        }
    }
}