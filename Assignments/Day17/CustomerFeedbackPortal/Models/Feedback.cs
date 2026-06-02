using System.ComponentModel.DataAnnotations;

namespace CustomerFeedbackPortal.Models
{
    public class Feedback
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Rating { get; set; }

        public string Comments { get; set; }
    }
}