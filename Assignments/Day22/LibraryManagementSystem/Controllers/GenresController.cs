using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public GenresController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Genres.ToList());
        }

        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();

            return Ok(genre);
        }
    }
}