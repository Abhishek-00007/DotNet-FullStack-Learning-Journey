using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Data;
using BookStoreApp.Models;

namespace BookStoreApp.Controllers;

public class BookController : Controller
{
    private readonly BookRepository _repository;

    public BookController(BookRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var books = _repository.GetAllBooks();
        return View(books);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Book book)
    {
        if (ModelState.IsValid)
        {
            _repository.AddBook(book);
            return RedirectToAction("Index");
        }

        return View(book);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var book = _repository.GetBookById(id);

        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    [HttpPost]
    public IActionResult Edit(Book book)
    {
        if (ModelState.IsValid)
        {
            _repository.UpdateBook(book);
            return RedirectToAction("Index");
        }

        return View(book);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        _repository.DeleteBook(id);

        return RedirectToAction("Index");
    }
}