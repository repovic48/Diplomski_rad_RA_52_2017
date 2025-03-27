using restaurant_service.Model;
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

            var restaurant = await context.Restaurants
                .FirstOrDefaultAsync(u => u.email == email);

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

            var food = await context.Foods
                .FirstOrDefaultAsync(u => u.id == id);

            if (food == null)
                return false;

            context.Foods.Remove(food);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Restaurant> Register(Restaurant new_restaurant)
        {
            if (new_restaurant == null)
            {
                throw new ArgumentNullException(nameof(new_restaurant), "New user cannot be null");
            }

            context.Add(new_restaurant);

            await context.SaveChangesAsync();

            return new_restaurant;
        }

        public async Task<Food> AddFood(Food new_food)
        {
            if (new_food == null)
            {
                throw new ArgumentNullException(nameof(new_food), "New food cannot be null");
            }

            context.Add(new_food);

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
            {
                throw new ArgumentException("Id cannot be null or empty", nameof(id));
            }

            var foods = await context.Foods
                .Where(f => f.restourant_id == id)
                .ToListAsync();

            return foods;
        }

        public async Task<Restaurant> GetRestaurantById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty", nameof(id));

            var restaurant = await context.Restaurants
                .FirstOrDefaultAsync(u => u.id == id);

            return restaurant;
        }
    }
}
