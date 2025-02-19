using user_service.Model;

namespace user_service.Repositories
{
    public interface IUserRepository
    {
        string SayHello();
        public Task<User> RegisterUser(User new_user);
        public Task<List<User>> GetAllUsers();
        public Task<User?> GetUserByEmail(string email);
        public Task<bool> DeleteUserByEmail(string email);
    }
}