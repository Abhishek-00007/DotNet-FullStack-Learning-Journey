using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingMVC.Controllers
{
    public class ProductsController : Controller
    {
        [Route("Products/{category}/{id:int}")]
        public IActionResult Details(string category, int id)
        {
            ViewBag.Category = category;
            ViewBag.Id = id;

            return View();
        }

        [Route("Products/Guid/{productId}")]
        public IActionResult ProductGuid(Guid productId)
        {
            return Content($"Valid GUID: {productId}");
        }
    }
}