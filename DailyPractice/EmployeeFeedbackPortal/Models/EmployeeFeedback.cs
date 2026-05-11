using System.ComponentModel.DataAnnotations;

namespace EmployeeFeedbackPortal.Models
{
    public class EmployeeFeedback
    {
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Feedback is required")]
        public string Feedback { get; set; }
    }
}