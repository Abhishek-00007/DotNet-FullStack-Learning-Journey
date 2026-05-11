using Microsoft.AspNetCore.Mvc;

namespace StudentPortalApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username)
        {
            HttpContext.Session.SetString("Username", username);
            return RedirectToAction("Dashboard");
        }
        public IActionResult Dashboard()
        {
            Response.Cookies.Append("Theme", "Dark");
            var theme = Request.Cookies["Theme"];
            var user = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("Login");
            }
            return Content($"Welcome {user} | Theme: {theme}");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}