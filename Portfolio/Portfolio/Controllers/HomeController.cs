using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.DAL;
using Portfolio.Models;
using Portfolio.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Controllers
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
            About about = _context.about.ToList().FirstOrDefault();
            List<Social> social = _context.social.ToList();
            Interest interest = _context.interest.FirstOrDefault();
            HomeVm hmv = new HomeVm()
            {
                about = about,
                socials = social,
                interest = interest
            };
            return View(hmv);
        }
    }
}
