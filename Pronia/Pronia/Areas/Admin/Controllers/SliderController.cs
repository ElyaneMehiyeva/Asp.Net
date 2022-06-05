using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Pronia.DAL;
using Pronia.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private AppDbContext _context { get; }
        private IWebHostEnvironment _env;
        public SliderController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.sliders.ToList();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExists = _context.sliders.Any(s => s.Name.ToLower().Trim() == slider.Name.ToLower().Trim());
            if (isExists)
            {
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + slider.ImageFile.FileName;
            string folderName = Path.Combine(_env.WebRootPath, "files", fileName);
            using (FileStream fs = new FileStream(folderName, FileMode.Create))
            {
                slider.ImageFile.CopyTo(fs);
            }

            slider.Image = fileName;
            _context.sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Slider slider = _context.sliders.Find(id);
            if(slider == null)
            {
                return NotFound();
            }
            if (System.IO.File.Exists(Path.Combine(_env.WebRootPath,"files",slider.Image)))
            {
                System.IO.File.Delete(Path.Combine(_env.WebRootPath, "files", slider.Image));
            }
            _context.sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } 
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Slider slider = _context.sliders.Find(id);

            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if(slider.Id != id)
            {
                return RedirectToAction("Index");
            }
            Slider sliderDb = _context.sliders.Find(id);
            if (sliderDb == null)
            {
                return NotFound();
            }
            sliderDb.Name = slider.Name;
            sliderDb.Description = slider.Description;
            sliderDb.Percent = slider.Percent;
            if (System.IO.File.Exists(Path.Combine(_env.WebRootPath, "files", sliderDb.Image)))
            {
                System.IO.File.Delete(Path.Combine(_env.WebRootPath, "files", sliderDb.Image));
            }
            string fileName = Guid.NewGuid().ToString() + slider.ImageFile.FileName;
            string folderName = Path.Combine(_env.WebRootPath, "files", fileName);
            using (FileStream fs = new FileStream(folderName, FileMode.Create))
            {
                slider.ImageFile.CopyTo(fs);
            }

            sliderDb.Image = fileName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
