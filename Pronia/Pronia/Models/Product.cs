using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pronia.Models
{
    public class Product
    {
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string Description { get; set; }
        [Required, Range(0, 5)]
        public int Raiting { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public int StockCount { get; set; }        
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<ProductImage> ProductImages { get; set; }

        public List<ProductColor> ProductColors { get; set; }
        [NotMapped]
        public List<int> ColorIDS { get; set; }        

        [NotMapped]
        public IFormFileCollection Images  { get; set; }

        [NotMapped,Required]
        public string MainPhotoSrc { get; set; }
    }
}
