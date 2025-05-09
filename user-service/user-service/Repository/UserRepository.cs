using user_service.Model;
using System.Threading.Tasks;
using user_service.DBContext;
using Microsoft.EntityFrameworkCore;

namespace user_service.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string SayHello()
        {
            return "Hello from user REST microservice :)";
        }

        public async Task<bool> DeleteUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));

            var user = await context.Users
                .FirstOrDefaultAsync(u => u.email == email);

            if (user == null)
                return false;

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<User> RegisterUser(User new_user)
        {
            if (new_user == null)
            {
                throw new ArgumentNullException(nameof(new_user), "New user cannot be null");
            }

            context.Add(new_user);

            await context.SaveChangesAsync();

            return new_user;
        }

        public async Task<User> UpdateUser(User updated_user)
        {
            if (updated_user == null)
            {
                throw new ArgumentNullException(nameof(updated_user), "Updated user cannot be null");
            }

            var existingUser = await context.Users.FindAsync(updated_user.id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {updated_user.id} not found");
            }

            context.Entry(existingUser).CurrentValues.SetValues(updated_user);
            await context.SaveChangesAsync();

            return existingUser;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await context.Users.ToListAsync();
        }
        public async Task<User?> GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));

            return await context.Users
                .FirstOrDefaultAsync(user => user.email == email);
        }
        public async Task<List<string>> GetAllEmails()
        {
            return await context.Users
                                .Select(u => u.email) 
                                .ToListAsync();        
        }
    }
}
