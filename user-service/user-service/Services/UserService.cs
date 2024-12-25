using user_service.Repositories;
using user_service.Model;

namespace user_service.Services 
{
    public class UserService : IUserService
    {
        private readonly IUserRepository user_repository;

        public UserService(IUserRepository user_repository)
        {
            this.user_repository = user_repository;
        }

        public string SayHello()
        {
            return user_repository.SayHello();
        }

        public async Task<User> RegisterUser(UserDTO new_userDTO)
        {
            User new_user = new User(new_userDTO);
            new_user.id = Guid.NewGuid().ToString();
            return await this.user_repository.RegisterUser(new_user);
        }
    }
}
