using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages
{
    public class ItemsModel : PageModel
    {
        public List<string> Items { get; set; }

        public void OnGet()
        {
            Items = ItemStore.Items;
        }
    }
}