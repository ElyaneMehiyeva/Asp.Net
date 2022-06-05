using System.ComponentModel.DataAnnotations;

namespace Pronia.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public int Percent { get; set; }
        [Required,MaxLength(40)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
