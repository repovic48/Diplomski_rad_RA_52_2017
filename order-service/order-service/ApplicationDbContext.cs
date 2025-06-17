using Microsoft.EntityFrameworkCore;
using order_service.Model;

namespace order_service.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasMany(r => r.items)
                .WithOne() 
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}