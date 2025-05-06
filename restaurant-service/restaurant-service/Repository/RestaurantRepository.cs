using restaurant_service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restaurant_service.DBContext;
using Microsoft.EntityFrameworkCore;

namespace restaurant_service.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDbContext context;
        
        public RestaurantRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string SayHello()
        {
            return "Hello from restaurant REST microservice :)";
        }

        public async Task<bool> DeleteRestaurantByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));

            var restaurant = await context.Restaurants.FirstOrDefaultAsync(u => u.email == email);

            if (restaurant == null)
                return false;

            context.Restaurants.Remove(restaurant);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFoodById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty", nameof(id));

            var food = await context.Foods.FirstOrDefaultAsync(u => u.id == id);

            if (food == null)
                return false;

            context.Foods.Remove(food);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Restaurant> Register(Restaurant new_restaurant)
        {
            if (new_restaurant == null)
                throw new ArgumentNullException(nameof(new_restaurant), "New restaurant cannot be null");

            await context.Restaurants.AddAsync(new_restaurant);
            await context.SaveChangesAsync();
            return new_restaurant;
        }

        public async Task<Food> AddFood(Food new_food)
        {
            if (new_food == null)
                throw new ArgumentNullException(nameof(new_food), "New food cannot be null");

            await context.Foods.AddAsync(new_food);
            await context.SaveChangesAsync();
            return new_food;
        }

        public async Task<List<Restaurant>> GetAllRestaurants()
        {
            return await context.Restaurants.ToListAsync();
        }

        public async Task<List<Food>> GetAllFoods()
        {
            return await context.Foods.ToListAsync();
        }

        public async Task<List<Food>> GetFoodsByRestaurantId(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty", nameof(id));
                
            return await context.Foods
                .Where(f => f.restaurant_id == id)
                .ToListAsync();
        }
        public async Task<List<Notification>> GetNotificationsByRestaurantId(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty", nameof(id));
                
            return await context.Notifications
                .Where(f => f.restaurant_id == id)
                .ToListAsync();
        }
        
        public async Task<Restaurant> UpdateRestaurant(Restaurant updatedRestaurant)
        {
            if (updatedRestaurant == null)
                throw new ArgumentNullException(nameof(updatedRestaurant), "Updated restaurant cannot be null");

            var existingRestaurant = await context.Restaurants.FindAsync(updatedRestaurant.id);
            if (existingRestaurant == null)
                throw new KeyNotFoundException($"Restaurant with ID {updatedRestaurant.id} not found");

            context.Entry(existingRestaurant).CurrentValues.SetValues(updatedRestaurant);
            await context.SaveChangesAsync();
            return existingRestaurant;
        }
        public async Task<Food> UpdateFood(Food updatedFood)
        {
            if (updatedFood == null)
                throw new ArgumentNullException(nameof(updatedFood), "Updated food cannot be null");

            var existingFood = await context.Foods.FindAsync(updatedFood.id);
            if (existingFood == null)
                throw new KeyNotFoundException($"Food with ID {updatedFood.id} not found");

            context.Entry(existingFood).CurrentValues.SetValues(updatedFood);
            await context.SaveChangesAsync();
            return existingFood;
        }
        public async Task<Restaurant> GetRestaurantById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty", nameof(id));

            return await context.Restaurants.FirstOrDefaultAsync(u => u.id == id);
        }
        public async Task<Food> GetFoodById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty", nameof(id));

            return await context.Foods.FirstOrDefaultAsync(u => u.id == id);
        }
        public async Task<Restaurant> GetRestaurantByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));

            return await context.Restaurants.FirstOrDefaultAsync(u => u.email == email);
        }
        public async Task<Notification> CreateNotification(Notification new_notification)
        {
            if (new_notification == null)
                throw new ArgumentNullException(nameof(new_notification), "New notification cannot be null");

            await context.Notifications.AddAsync(new_notification);
            await context.SaveChangesAsync();
            return new_notification;
        }
        public async Task<List<Notification>> GetAllNotifications()
        {
            return await context.Notifications.ToListAsync();
        }


        public async Task<Notification> GetNotificationById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty", nameof(id));

            return await context.Notifications.FirstOrDefaultAsync(u => u.id == id);
        }

        public async Task<bool> DeleteNotificationById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty", nameof(id));

            var notification = await context.Notifications.FirstOrDefaultAsync(u => u.id == id);

            if (notification == null)
                return false;

            context.Notifications.Remove(notification);
            await context.SaveChangesAsync();
            return true;
        }

    }
}
