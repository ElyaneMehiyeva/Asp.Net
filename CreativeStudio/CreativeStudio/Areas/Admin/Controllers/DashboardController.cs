using CreativeStudio.DAL;
using CreativeStudio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CreativeStudio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private AppDbContext _context { get; }
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Main> mainDb = _context.Main.ToList();
            if (mainDb.Count == 0)
            {
                return View();
            } else
            {
                return View(mainDb[0]);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Main main)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                List<Main> mainDb = _context.Main.ToList();
                if (mainDb.Count == 0)
                {
                    _context.Main.Add(main);
                }
                else
                {
                    Main getMain = mainDb[0];
                    getMain.Icon = main.Icon;
                    getMain.Description = main.Description;
                    getMain.Title = main.Title;

                }
                _context.SaveChanges();
                return View();
            }
        }
    }
}
