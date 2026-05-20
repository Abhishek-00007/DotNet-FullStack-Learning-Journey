using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages
{
    public class AddItemModel : PageModel
    {
        [BindProperty]
        public string NewItem { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(NewItem))
            {
                ItemStore.Items.Add(NewItem);
            }

            return RedirectToPage("/Items");
        }
    }
}