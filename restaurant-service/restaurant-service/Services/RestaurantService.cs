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

        public RestaurantService(IRestaurantRepository restaurant_repository)
        {
            this.restaurant_repository = restaurant_repository;
        }
        public string SayHello()
        {
            return this.restaurant_repository.SayHello();
        }
        public async Task<Restaurant> Register(RestaurantDTO new_restaurantDTO)
        {
            Restaurant new_restaurant = new Restaurant(new_restaurantDTO);
            new_restaurant.id = Guid.NewGuid().ToString();
            Random random = new Random();
            int verification_code = random.Next(1000, 10000);
            new_restaurant.verification_code = verification_code;

            await SendEmail(new_restaurant.email, new_restaurant.verification_code);

            return await this.restaurant_repository.Register(new_restaurant);
        }
        public async Task<Food> AddFood(FoodDTO new_foodDTO)
        {
            Food new_food = new Food(new_foodDTO);
            new_food.id = Guid.NewGuid().ToString();

            return await this.restaurant_repository.AddFood(new_food);
        }

        public async Task<List<Restaurant>> GetAllRestaurants()
        {
            var restaurants = await this.restaurant_repository.GetAllRestaurants();
            foreach (Restaurant restaurant in restaurants) 
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

        public async Task<Restaurant> GetRestaurantById(string id){
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty", nameof(id));

            var restaurant = await restaurant_repository.GetRestaurantById(id);
            restaurant.menu = await restaurant_repository.GetFoodsByRestaurantId(restaurant.id);
            return restaurant;
        }

        public async Task SendEmail(string recipientEmail, int verificationCode)
        {
            string sender_email = "narucirs.podrska@gmail.com";
            MailMessage mailMessage = new MailMessage(sender_email, recipientEmail);
            mailMessage.From = new MailAddress(sender_email);
            mailMessage.To.Add(recipientEmail);
            mailMessage.Subject = "Potvrda registracije";
            mailMessage.Body = $"Dobrodosli u nas program za partnere. Vas kod za potvrdu registracije: {verificationCode}";
            
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
