using user_service.Repositories;

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
    }
}
