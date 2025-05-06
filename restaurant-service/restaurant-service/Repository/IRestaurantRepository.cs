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
        public Task<Food> GetFoodById(string id);
        public Task<Restaurant> GetRestaurantById(string id);
        public Task<Restaurant> GetRestaurantByEmail(string email);
        public Task<Restaurant> UpdateRestaurant(Restaurant updatedRestaurant);
        public Task<Food> UpdateFood(Food updatedFood);
        public Task<Notification> CreateNotification(Notification new_notification);
        public  Task<List<Notification>> GetAllNotifications();
        public  Task<List<Notification>> GetNotificationsByRestaurantId(string id);
        public  Task<Notification> GetNotificationById(string id);
        public Task<bool> DeleteNotificationById(string id);
    }
}