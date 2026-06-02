using Microsoft.AspNetCore.Mvc;
using RegistrationSystem.Models;

namespace RegistrationSystem.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegistration user)
        {
            if (ModelState.IsValid)
            {
                return View("Success", user);
            }

            return View(user);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}