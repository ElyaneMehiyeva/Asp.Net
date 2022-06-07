using Portfolio.Models;
using System.Collections.Generic;

namespace Portfolio.ViewModels
{
    public class HomeVm
    {
        public About about { get; set; }
        public List<Social> socials { get; set; }
        public Interest interest { get; set; }
    }
}
