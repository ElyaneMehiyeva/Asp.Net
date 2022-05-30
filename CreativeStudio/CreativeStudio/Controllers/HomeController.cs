using CreativeStudio.DAL;
using CreativeStudio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CreativeStudio.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Main main = _context.Main.ToList()[0];
            return View(main);
        }

   
    }
}

