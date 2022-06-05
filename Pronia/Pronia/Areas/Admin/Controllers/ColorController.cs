using Microsoft.AspNetCore.Mvc;
using Pronia.DAL;
using Pronia.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        private readonly AppDbContext _context;
        public ColorController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            List<Color> colors = _context.colors.ToList();

            return View(colors);
        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Color color)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExist = _context.colors.Any(c => c.Name.Trim().ToLower() == color.Name.Trim().ToLower());
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu adda color var!");
                return View();
            }
            color.Name = color.Name.ToLower();
            _context.colors.Add(color);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Color color = _context.colors.Find(id);
            if (color == null)
            {
                return NotFound();
            }
            return View(color);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Color color)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (color.Id != id)
            {
                return RedirectToAction("Index");
            }
            Color colorDb = _context.colors.Find(id);
            if (colorDb == null)
            {
                return NotFound();
            }
            colorDb.Name = color.Name.ToLower();
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Color color = _context.colors.Find(id);

            if (color == null)
            {
                return NotFound();
            }
            _context.colors.Remove(color);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
