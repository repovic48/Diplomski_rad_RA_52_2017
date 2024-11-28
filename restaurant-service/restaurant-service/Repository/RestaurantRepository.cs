namespace restaurant_service.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        public string SayHello()
        {
            return "Hello from restaurant REST microservice :)";
        }
    }
}
