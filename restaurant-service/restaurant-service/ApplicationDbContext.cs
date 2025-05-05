using Microsoft.EntityFrameworkCore;
using restaurant_service.Model;

namespace restaurant_service.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>()
                .HasIndex(r => r.email)
                .IsUnique();

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.menu)
                .WithOne() 
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}

