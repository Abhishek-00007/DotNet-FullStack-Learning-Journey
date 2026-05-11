using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Data;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages
{
    public class AddItemModel : PageModel
    {
        [BindProperty]
        public Item NewItem { get; set; } = new();

        public IActionResult OnPost()
        {
            ItemStore.Items.Add(NewItem);

            return RedirectToPage("/Items");
        }
    }
}