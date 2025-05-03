using restaurant_service.Model;

namespace restaurant_service.Services
{
    public interface IRestaurantService
    {
        string SayHello();
        public Task<Restaurant> Register(RestaurantDTO new_restaurantDTO);
        public Task<List<Restaurant>> GetAllRestaurants();
        public Task<bool> DeleteRestaurantByEmail(string email);
        public Task<List<Food>> GetAllFoods();
        public Task<Food> AddFood(FoodDTO new_foodDTO);
        public Task<Food> UpdateFood(FoodDTO new_foodDTO);
        public Task<bool> DeleteFoodById(string id);
        public Task<List<Food>> GetFoodsByRestaurantId(string id);
        public Task<Restaurant> GetRestaurantById(string id);
        public Task<string> Login(RestaurantDTO restaurantDTO);
        public Task<Restaurant?> VerifyAccount(RestaurantDTO restaurantDTO);
        public Task<Restaurant> GetRestaurantByEmail(string email);
        public Task<Restaurant?> UpdateRestaurant(RestaurantDTO restaurantDTO);
    }
}