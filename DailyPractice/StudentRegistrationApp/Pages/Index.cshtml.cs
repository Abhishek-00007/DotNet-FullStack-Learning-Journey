using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentRegistrationApp.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string StudentName { get; set; }

    public string Message { get; set; }

    public void OnPost()
    {
        Message = "Student " + StudentName + " registered successfully!";
    }
}