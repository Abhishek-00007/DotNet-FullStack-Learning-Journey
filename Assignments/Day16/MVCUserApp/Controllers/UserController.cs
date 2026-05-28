using Microsoft.AspNetCore.Mvc;
using MVCUserApp.Models;

namespace MVCUserApp.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(User user)
        {
            return View(user);
        }
    }
}