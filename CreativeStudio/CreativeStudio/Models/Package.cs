using System.ComponentModel.DataAnnotations;

namespace CreativeStudio.Models
{
    public class Package
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string ItemOne { get; set; }
        [Required]
        public string ItemTwo { get; set; }
        [Required]
        public string ItemThree { get; set; }
        [Required]
        public string ItemFour { get; set; }

    }
}
