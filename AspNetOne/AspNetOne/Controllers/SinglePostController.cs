using Microsoft.AspNetCore.Mvc;

namespace AspNetOne.Controllers
{
    public class SinglePostController : Controller
    {
        public IActionResult Index(int? id)
        {
            return View();
        }
    }
}
