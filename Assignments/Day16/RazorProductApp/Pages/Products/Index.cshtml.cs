using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorProductApp.Models;

namespace RazorProductApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; } = new Product();

        public static List<Product> ProductList = new List<Product>();

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            Product.ProductID = ProductList.Count + 1;

            ProductList.Add(Product);

            return RedirectToPage();
        }
    }
}