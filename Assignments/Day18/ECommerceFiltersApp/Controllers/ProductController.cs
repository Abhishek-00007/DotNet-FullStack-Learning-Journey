using Microsoft.AspNetCore.Mvc;
using ECommerceFiltersApp.Models;

namespace ECommerceFiltersApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = 50000
                },
                new Product
                {
                    Id = 2,
                    Name = "Mobile",
                    Price = 25000
                }
            };

            return View(products);
        }

        public IActionResult TestError()
        {
            throw new Exception("Testing Global Exception Filter");
        }
    }
}