using Microsoft.EntityFrameworkCore;
using proj1.Models;
namespace proj1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=.;Database=AMVC_11;TrustServerCertificate=True;Trusted_Connection=True");
        }

    }
    
}
