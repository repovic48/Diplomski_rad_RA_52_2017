using user_service.Model;

namespace user_service.Services
{
    public interface IUserService
    {
        string SayHello();

        public Task<User> RegisterUser(UserDTO new_userDTO);
        public Task<string> Login(UserDTO userDTO);
        public Task<List<User>> GetAllUsers();
        public Task<bool> DeleteUserByEmail(string email);
        public Task<User?> VerifyAccount(UserDTO userDTO);
        public Task<User?> UpdateUser(UserDTO userDTO);
        public Task<User> GetUserByEmail(string email);
        public Task<List<string>> GetAllEmails();
    }
}