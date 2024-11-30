using Microsoft.EntityFrameworkCore;
using order_service.Model;

namespace order_service.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }

    }
}