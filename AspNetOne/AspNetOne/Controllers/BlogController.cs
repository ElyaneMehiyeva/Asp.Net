using AspNetOne.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetOne.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            List<Post> posts = new List<Post>()
            {
                new Post(){
                    Id = 1,
                    Name = "NEW CHILLS FOR SUMMER",
                    SubName ="By Admin on November 28, 2023",
                    Text ="You can replace all this text with your own text. You can remove any link to our website from this website template, you're free to use this website template without linking back to us. If you're having problems editing this website template.",
                    Link = "SinglePost/Index/"+1,
                    Img = "~/images/new-chills.png"
                },
                 new Post(){
                    Id = 2,
                    Name = "BERRIES ON THE GROVE",
                    SubName ="By Admin on November 28, 2023",
                    Text ="You can replace all this text with your own text. You can remove any link to our website from this website template, you're free to use this website template without linking back to us. If you're having problems editing this website template.",
                    Link = "SinglePost/Index/"+2,
                    Img = "~/images/berries.png"
                }
            };
            return View(posts);
        }
    }
}
