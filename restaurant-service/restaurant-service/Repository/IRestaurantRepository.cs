using restaurant_service.Model;

namespace restaurant_service.Repositories
{
    public interface IRestaurantRepository
    {
        string SayHello();
        public Task<Restaurant> Register(Restaurant new_restaurant);
        public Task<List<Restaurant>> GetAllRestaurants();
        public Task<bool> DeleteRestaurantByEmail(string email);
        public Task<bool> DeleteFoodById(string id);
        public  Task<List<Food>> GetAllFoods();
        public Task<Food> AddFood(Food new_food);
        public Task<List<Food>> GetFoodsByRestaurantId(string id);
        public Task<Restaurant> GetRestaurantById(string id);
    }
}