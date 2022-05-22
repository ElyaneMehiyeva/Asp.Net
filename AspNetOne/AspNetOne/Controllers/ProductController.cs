using Microsoft.AspNetCore.Mvc;

namespace AspNetOne.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
