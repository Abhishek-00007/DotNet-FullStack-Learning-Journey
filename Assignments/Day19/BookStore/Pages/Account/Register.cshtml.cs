using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookStore.Models;

namespace BookStore.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public User User { get; set; } = new();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            User.Role = "Customer";

            User.Id = UserStore.Users.Count + 1;

            UserStore.Users.Add(User);

            return RedirectToPage("Login");
        }
    }
}