using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookStore.Models;
using BookStore.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly IBookRepository _repository;

        public EditModel(IBookRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Book Book { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var book = _repository.GetById(id);

            if (book == null)
                return NotFound();

            Book = book;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _repository.Update(Book);

            return RedirectToPage("/Index");
        }
    }
}