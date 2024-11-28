namespace user_service.Repositories
{
    public class UserRepository : IUserRepository
    {
        public string SayHello()
        {
            return "Hello from user REST microservice :)";
        }
    }
}
