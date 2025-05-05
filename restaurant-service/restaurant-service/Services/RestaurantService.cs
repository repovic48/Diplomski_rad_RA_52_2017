using restaurant_service.Model;
using restaurant_service.Repositories;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace restaurant_service.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository restaurant_repository;
        private readonly TokenProvider token_provider;

        public RestaurantService(IRestaurantRepository restaurant_repository, TokenProvider token_provider)
        {
            this.restaurant_repository = restaurant_repository;
            this.token_provider = token_provider;
        }

        public string SayHello()
        {
            return this.restaurant_repository.SayHello();
        }

        public async Task<Restaurant> Register(RestaurantDTO new_restaurantDTO)
        {
            Restaurant new_restaurant = new Restaurant(new_restaurantDTO)
            {
                id = Guid.NewGuid().ToString(),
                verification_code = new Random().Next(1000, 10000)
            };

            await SendEmail(new_restaurant.email, "Potvrda registracije", $"Vas kod za potvrdu registracije: {new_restaurant.verification_code}");
            return await this.restaurant_repository.Register(new_restaurant);
        }

        public async Task<string> Login(RestaurantDTO restaurantDTO)
        {
            var existingRestaurant = await restaurant_repository.GetRestaurantByEmail(restaurantDTO.email);

            if (existingRestaurant != null && existingRestaurant.password == restaurantDTO.password)
            {
                return token_provider.Create(existingRestaurant);
            }

            return null;
        }

        public async Task<Food> AddFood(FoodDTO new_foodDTO)
        {
            Food new_food = new Food(new_foodDTO)
            {
                id = Guid.NewGuid().ToString()
            };

            return await this.restaurant_repository.AddFood(new_food);
        }

        public async Task<Notification?> CreateNotification(NotificationDTO new_notificationDTO)
        {
            Notification new_notification = new Notification(new_notificationDTO)
            {
                id = Guid.NewGuid().ToString()
            };

            return await this.restaurant_repository.CreateNotification(new_notification);
        }

        public  async Task<List<Notification>> GetAllNotifications()
        {
            var notifications = await this.restaurant_repository.GetAllNotifications();

            return notifications;
        }


        public async Task<List<Restaurant>> GetAllRestaurants()
        {
            var restaurants = await this.restaurant_repository.GetAllRestaurants();
            foreach (var restaurant in restaurants)
            {
                restaurant.menu = await restaurant_repository.GetFoodsByRestaurantId(restaurant.id);
            }
            return restaurants;
        }

        public async Task<bool> DeleteRestaurantByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));

            return await restaurant_repository.DeleteRestaurantByEmail(email);
        }

        public async Task<bool> DeleteFoodById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty", nameof(id));

            return await restaurant_repository.DeleteFoodById(id);
        }

        public async Task<List<Food>> GetFoodsByRestaurantId(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty", nameof(id));

            return await restaurant_repository.GetFoodsByRestaurantId(id);
        }

        public async Task<List<Food>> GetAllFoods()
        {
            return await this.restaurant_repository.GetAllFoods();
        }

        public async Task<Restaurant> GetRestaurantById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty", nameof(id));

            var restaurant = await restaurant_repository.GetRestaurantById(id);
            if (restaurant == null)
                throw new ArgumentException("Restaurant not found", nameof(id));

            restaurant.menu = await restaurant_repository.GetFoodsByRestaurantId(restaurant.id);
            return restaurant;
        }

        public async Task<Restaurant> GetRestaurantByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));

            var restaurant = await restaurant_repository.GetRestaurantByEmail(email);
            if (restaurant == null)
                throw new ArgumentException("Restaurant not found", nameof(email));

            restaurant.menu = await restaurant_repository.GetFoodsByRestaurantId(restaurant.id);
            return restaurant;
        }

        public async Task<Restaurant?> VerifyAccount(RestaurantDTO restaurantDTO)
        {
            var existingRestaurant = await restaurant_repository.GetRestaurantByEmail(restaurantDTO.email);
            if (existingRestaurant != null && existingRestaurant.verification_code == restaurantDTO.verification_code)
            {
                existingRestaurant.account_active = true;
                return await restaurant_repository.UpdateRestaurant(existingRestaurant);
            }
            return null;
        }

        public async Task<Restaurant?> UpdateRestaurant(RestaurantDTO restaurantDTO)
        {

            Restaurant tempRestaurant = new Restaurant(restaurantDTO);

            if (tempRestaurant != null)
            {
                var existingRestaurant = await restaurant_repository.GetRestaurantByEmail(tempRestaurant.email);
                if(existingRestaurant != null){
                    var updated_restaurant = await restaurant_repository.UpdateRestaurant(tempRestaurant);
                    return updated_restaurant;
                }
            }
            return null;
        }

        public async Task<Food?> UpdateFood(FoodDTO foodDTO)
        {

            Food tempFood = new Food(foodDTO);

            if (tempFood != null)
            {
                var existingFood = await restaurant_repository.GetFoodById(tempFood.id);
                if(existingFood != null){
                    var updated_food = await restaurant_repository.UpdateFood(tempFood);
                    return updated_food;
                }
            }
            return null;
        }

        public async Task<List<string>> NotifyUsers(string notification_id, List<string> emails)
        {
            // Assuming GetNotificationById is an async method
            var notification = await restaurant_repository.GetNotificationById(notification_id);

            if (notification == null)
            {
                throw new Exception("Notification not found.");
            }

            foreach (string email in emails)
            {
                await SendEmail(email, notification.subject, notification.content);
            }
            return emails;
        }


        public async Task SendEmail(string recipientEmail, string email_subject, string email_body)
        {
            string sender_email = "narucirs.podrska@gmail.com";
            MailMessage mailMessage = new MailMessage(sender_email, recipientEmail);
            mailMessage.From = new MailAddress(sender_email);
            mailMessage.To.Add(recipientEmail);
            mailMessage.Subject = email_subject; //"Potvrda registracije";
            mailMessage.Body = email_body; //$"Vas kod za potvrdu registracije: {verificationCode}";
            
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(sender_email, "whkn gznt iedy bcbt ");
            smtpClient.EnableSsl = true;

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine("Email Sent Successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
