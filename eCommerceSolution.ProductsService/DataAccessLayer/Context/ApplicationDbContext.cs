using eCommerce.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;


namespace eCommerce.DataAccessLayer.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add any additional model configurations here
        }
        // Define DbSet properties for your entities
         public DbSet<Product> Products { get; set; }
        
    }
}
