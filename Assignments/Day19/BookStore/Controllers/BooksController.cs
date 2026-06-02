using Microsoft.AspNetCore.Mvc;
using BookStore.Repositories;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var books = _repository.GetAll();

            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _repository.GetById(id);

            if (book == null)
                return NotFound();

            return View(book);
        }
    }
}