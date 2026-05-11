using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeeFeedbackPortal.Models;

namespace EmployeeFeedbackPortal.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public EmployeeFeedback Employee { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
            Employee = new EmployeeFeedback
            {
                EmployeeName = "Abhishek"
            };
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            Message = "Feedback submitted successfully!";

            Employee.EmployeeName = "Abhishek";
        }
    }
}