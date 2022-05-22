using Microsoft.AspNetCore.Mvc;

namespace AspNetOne.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
