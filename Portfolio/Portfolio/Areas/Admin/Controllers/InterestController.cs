using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InterestController : Controller
    {
        private readonly AppDbContext _context;
        public InterestController(AppDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
            Interest interest = _context.interest.ToList().FirstOrDefault();
            return View(interest);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Interest interest)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Interest interest1 = _context.interest.ToList().FirstOrDefault();
            if (interest1 == null)
            {
                return NotFound();
            }
            interest1.Title = interest.Title;
            interest1.Text = interest.Text;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
