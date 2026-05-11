using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Data;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages
{
    public class ItemsModel : PageModel
    {
        public List<Item> ItemList { get; set; } = new();

        public void OnGet()
        {
            ItemList = ItemStore.Items;
        }
    }
}