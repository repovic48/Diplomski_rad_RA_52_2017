using user_service.Services;

namespace user_service.Services 
{
    public class UserService : IUserService
    {
        public string SayHello()
        {
            return "Hello from user service :)";
        }
    }
}
