namespace restaurant_service.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Restaurant
    {
        [Key]
        public string id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        public List<Food> menu { get; set; } = new List<Food>();

        public int verification_code { get; set; }

        public bool account_active { get; set; }

        public bool account_suspended { get; set; }

        [Required]
        public int postal_code { get; set; }

        public Restaurant() { }

        public Restaurant(string id, string name, string address, string email, string password, int postal_code)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.email = email;
            this.password = password;
            this.menu = new List<Food>();
            this.verification_code = 0000;
            this.account_active = false;
            this.account_suspended = false;
            this.postal_code = postal_code;
        }

        public Restaurant(RestaurantDTO restaurantDTO)
        {
            this.id = restaurantDTO.id;
            this.name = restaurantDTO.name;
            this.address = restaurantDTO.address;
            this.email = restaurantDTO.email;
            this.password = "";  
            this.menu = restaurantDTO.menu.Select(f => new Food(f)).ToList();
            this.verification_code = restaurantDTO.verification_code;
            this.account_active = restaurantDTO.account_active;
            this.account_suspended = restaurantDTO.account_suspended;
            this.postal_code = restaurantDTO.postal_code;
        }
    }
}
