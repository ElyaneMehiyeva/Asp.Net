using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base (options)
        {

        }
        public DbSet<About> about { get; set; }
        public DbSet<Social> social { get; set; }
        public DbSet<Interest> interest { get; set; }
    }
}
