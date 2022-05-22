using Microsoft.AspNetCore.Mvc;

namespace AspNetOne.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
