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
    public class SocialController : Controller
    {
        public readonly AppDbContext _context;
        public SocialController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Social> socials = _context.social.ToList();
            return View(socials);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Social socail)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.social.Add(socail);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            Social social = _context.social.Find(id);
            if (social == null)
            {
                return NotFound();
            }
            _context.social.Remove(social);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
