using CreativeStudio.Models;
using Microsoft.EntityFrameworkCore;

namespace CreativeStudio.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }
        public DbSet<Main> Main { get; set; }
    }
}
