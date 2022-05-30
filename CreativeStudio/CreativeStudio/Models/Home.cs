using System.ComponentModel.DataAnnotations;

namespace CreativeStudio.Models
{
    public class Home
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Facebook { get; set; }
        [Required]
        public string Instagram { get; set; }
        [Required]
        public string Twitter { get; set; }
        [Required]
        public string Youtube { get; set; }
        [Required]
        public string ButtonLink { get; set; }

    }
}
