using System.ComponentModel.DataAnnotations;

namespace CreativeStudio.Models
{
    public class About
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string BackgroundColor { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string SubTitle { get; set; }
        [Required]
        public string Description { get; set; }
        public string ListOne { get; set; }
        public string ListTwo { get; set; }
        public string ListThree { get; set; }

    }
}
