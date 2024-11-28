using restaurant_service.Repositories;

namespace restaurant_service.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository restaurant_repository;

        public RestaurantService(IRestaurantRepository restaurant_repository)
        {
            this.restaurant_repository = restaurant_repository;
        }
        public string SayHello()
        {
            return this.restaurant_repository.SayHello();
        }
    }
}
