using Microsoft.AspNetCore.Mvc;
using CourseRegistrationPortal.Models;
using System.ComponentModel.Design;
using System.Reflection.PortableExecutable;

namespace CourseRegistrationPortal.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Registration Successful";
            }
            return View(student);
        }
    }
}