using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pronia.DAL;
using Pronia.Models;
using Pronia.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pronia.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.sliders.ToList();
            List<Category> categories = _context.categories.ToList();
            List<Product> products = _context.products.OrderByDescending(product => product.Id).Take(8).Include(p=>p.ProductImages).ToList();
            _ViewModel vm = new _ViewModel()
            {
                sliders = sliders,
                products = products,
                categories = categories
            };
            return View(vm);
        }

    }
}
