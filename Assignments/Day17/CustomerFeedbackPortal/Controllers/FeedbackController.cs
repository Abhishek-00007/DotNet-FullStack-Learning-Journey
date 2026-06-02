using Microsoft.AspNetCore.Mvc;
using CustomerFeedbackPortal.Models;

namespace CustomerFeedbackPortal.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                return View("Success", feedback);
            }

            return View(feedback);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}