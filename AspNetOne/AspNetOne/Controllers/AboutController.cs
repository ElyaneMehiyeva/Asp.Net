using Microsoft.AspNetCore.Mvc;

namespace AspNetOne.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
