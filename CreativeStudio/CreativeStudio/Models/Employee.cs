using System.ComponentModel.DataAnnotations;

namespace CreativeStudio.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public string Facebook { get; set; }
        [Required]
        public string Twitter { get; set; }
        [Required]
        public string Google { get; set; }
        [Required]
        public string Image { get; set; }
      
    }
}
