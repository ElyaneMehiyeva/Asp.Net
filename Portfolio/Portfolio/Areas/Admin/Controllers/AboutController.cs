using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL;
using Portfolio.Models;
using System.Linq;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        public readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            About about = _context.about.ToList().FirstOrDefault();
            return View(about);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(About about)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            About about1 = _context.about.ToList().FirstOrDefault();
            if (about1 == null)
            {
                return NotFound();
            }
            about1.Name = about.Name;
            about1.SurName = about.SurName;
            about1.Email = about.Email;
            about1.Number = about.Number;
            about1.AboutText = about.AboutText;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
