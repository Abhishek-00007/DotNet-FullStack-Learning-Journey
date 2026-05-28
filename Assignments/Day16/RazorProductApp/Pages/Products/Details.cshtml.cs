using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorProductApp.Models;

namespace RazorProductApp.Pages.Products
{
    public class DetailsModel : PageModel
    {
        public Product Product { get; set; } = new Product();

        public void OnGet(int id)
        {
            Product = IndexModel.ProductList
                .FirstOrDefault(p => p.ProductID == id);
        }
    }
}