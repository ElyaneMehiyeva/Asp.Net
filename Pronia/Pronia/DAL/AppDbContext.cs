using Microsoft.EntityFrameworkCore;
using Pronia.Models;

namespace Pronia.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slider> sliders { get; set; }
        public DbSet<Color> colors { get; set; }
        public DbSet<Category> categories { get; set; }

        public DbSet<Product> products { get; set; }

        public DbSet<ProductImage> productImages { get; set; }

        public DbSet<ProductColor> productColors { get; set; }

    }
}