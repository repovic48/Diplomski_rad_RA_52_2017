using Microsoft.EntityFrameworkCore;
using comment_service.Model;

namespace comment_service.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Comment> CommentsT { get; set; }
        public DbSet<News> News { get; set; }

    }
}