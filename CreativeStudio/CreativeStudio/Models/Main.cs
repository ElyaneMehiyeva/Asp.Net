using System.ComponentModel.DataAnnotations;

namespace CreativeStudio.Models
{
    public class Main
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
