using restaurant_service.Services;

namespace restaurant_service.Services 
{
    public class RestaurantService : IRestaurantService
    {
        public string SayHello()
        {
            return "Hello from restaurant service :)";
        }
    }
}
