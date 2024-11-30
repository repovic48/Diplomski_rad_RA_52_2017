using Microsoft.EntityFrameworkCore;
using restaurant_service.Model;

namespace restaurant_service.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Restaurant> Restaurants { get; set; }

    }
}