using System.ComponentModel.DataAnnotations;

namespace CreativeStudio.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public int Raiting { get; set; }


    }
}
