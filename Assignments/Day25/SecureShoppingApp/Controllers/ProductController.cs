using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureShoppingApp.Data;
using SecureShoppingApp.Models;

namespace SecureShoppingApp.Controllers;

[Authorize]
public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;

        if (!_context.Products.Any())
        {
            _context.Products.AddRange(
                new Product
                {
                    Name = "Laptop",
                    Description = "Gaming Laptop",
                    Price = 75000
                },
                new Product
                {
                    Name = "Phone",
                    Description = "Android Phone",
                    Price = 25000
                }
            );

            _context.SaveChanges();
        }
    }

    public IActionResult Index()
    {
        return View(_context.Products.ToList());
    }

    public IActionResult Details(int id)
    {
        var product = _context.Products.FirstOrDefault(x => x.Id == id);

        if (product == null)
            return NotFound();

        return View(product);
    }
}