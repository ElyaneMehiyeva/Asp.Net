using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.DAL;
using Pronia.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Product> products = _context.products.Include(p => p.ProductImages).Include(p => p.Category).Include(p=>p.ProductColors).ThenInclude(c=>c.Color).ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            List<Category> categories = _context.categories.ToList();
            List<Color> colors = _context.colors.ToList();
            ViewBag.Categories = categories;
            ViewBag.Colors = colors;
            return View();
        }


        // Product Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            List<Category> categories = _context.categories.ToList();
            List<Color> colors = _context.colors.ToList();
            ViewBag.Categories = categories;
            ViewBag.Colors = colors;
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExists = _context.products.Any(p => p.Name.ToLower().Trim() == product.Name.ToLower().Trim());
            if (isExists)
            {
                return View();
            }

           
            product.ProductImages = new List<ProductImage>();
            foreach (var image in product.Images)
            {
                string fileName = Guid.NewGuid().ToString() + image.FileName;
                string folderName = Path.Combine(_env.WebRootPath,"files",fileName);
                using(FileStream fs = new FileStream(folderName, FileMode.Create))
                {
                    image.CopyTo(fs);
                }
                ProductImage productImage = new ProductImage()
                {
                    IsMain = image.FileName==product.MainPhotoSrc?true:false,
                    Product = product,
                    Source = fileName,
                };
                product.ProductImages.Add(productImage);
            }
           
            product.ProductColors = new List<ProductColor>();

            foreach (int colorId in product.ColorIDS)
            {
                Color color = _context.colors.Find(colorId);
                if(color == null)
                {
                    return NotFound();
                } else
                {
                    ProductColor productColor = new ProductColor()
                    {
                        Product = product,
                        ColorId = colorId,
                    };
                    product.ProductColors.Add(productColor);
                }                
            }
            

            _context.products.Add(product);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}
