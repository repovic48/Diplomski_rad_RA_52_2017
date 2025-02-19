using user_service.Model;

namespace user_service.Services
{
    public interface IUserService
    {
        string SayHello();

        public Task<User> RegisterUser(UserDTO new_userDTO);
        public Task<User?> Login(UserDTO userDTO);
        public Task<List<User>> GetAllUsers();
        public Task<bool> DeleteUserByEmail(string email);
    }
}