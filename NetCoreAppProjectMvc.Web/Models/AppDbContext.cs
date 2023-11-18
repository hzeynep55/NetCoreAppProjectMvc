using Microsoft.EntityFrameworkCore;

namespace NetCoreAppProjectMvc.Web.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }

        public DbSet<Product> Products { get; set; }
    }
}
