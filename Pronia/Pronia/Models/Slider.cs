using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pronia.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public int Percent { get; set; }
        [Required,MaxLength(40)]
        public string Name { get; set; }
        public string Description { get; set; }
        
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
