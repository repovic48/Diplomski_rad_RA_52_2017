using user_service.Model;

namespace user_service.Repositories
{
    public interface IUserRepository
    {
        string SayHello();
        public Task<User> RegisterUser(User new_user);
    }
}