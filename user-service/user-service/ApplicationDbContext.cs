using Microsoft.EntityFrameworkCore;
using user_service.Model;

namespace user_service.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create a random person
            var random = new Random();
            var randomPerson = new Person
            {
                user_id = Guid.NewGuid().ToString(), // Generate a random GUID for the user_id
                name = $"Name{random.Next(1, 100)}", // Generate random name
                surname = $"Surname{random.Next(1, 100)}", // Generate random surname
                password = "password123", // Default password for testing
                email = $"test{random.Next(1, 100)}@example.com", // Random email
                address = $"Street {random.Next(1, 100)}, City", // Random address
                postal_code = random.Next(1000, 9999) // Random postal code
            };

            // Add the random person to the Persons table
            modelBuilder.Entity<Person>().HasData(randomPerson);
        }
    }
}