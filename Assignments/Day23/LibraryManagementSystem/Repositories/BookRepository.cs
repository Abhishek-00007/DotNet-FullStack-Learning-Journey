using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksWithDetailsAsync()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .ToListAsync();
        }
    }
}