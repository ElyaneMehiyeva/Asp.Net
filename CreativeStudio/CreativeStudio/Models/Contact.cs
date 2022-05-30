using System.ComponentModel.DataAnnotations;

namespace CreativeStudio.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string OfficeTelephone { get; set; }
        [Required]
        public string Inquires { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
