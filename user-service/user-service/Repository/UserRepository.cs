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
    }
}
