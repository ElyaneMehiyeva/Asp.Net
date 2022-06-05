using Microsoft.AspNetCore.Mvc;
using Pronia.DAL;
using Pronia.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
       
        public IActionResult Index()
        {
            List<Category> categories = _context.categories.ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExist = _context.categories.Any(c => c.Name.Trim().ToLower() == category.Name.Trim().ToLower());
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu adda category var");
                return View();
            }
            category.Name = category.Name.Trim();
            _context.categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Category category = _context.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Category category = _context.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Category categoryDb = _context.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
       
            categoryDb.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");
            



        }
    }
}
