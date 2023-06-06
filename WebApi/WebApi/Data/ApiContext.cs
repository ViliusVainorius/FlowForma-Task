using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clothing>().HasBaseType<Product>();
            modelBuilder.Entity<Shoes>().HasBaseType<Product>();

            // Additional configurations for other entities

            base.OnModelCreating(modelBuilder);
        }
    }
}
