namespace restaurant_service.Model
{
    public class RestaurantDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<FoodDTO> menu { get; set; }
        public int verification_code { get; set; }
        public bool account_active { get; set; }
        public bool account_suspended { get; set; }
        public int postal_code { get; set; }

        public RestaurantDTO() { }

        public RestaurantDTO(string id, string name, string address, string email, string password, List<FoodDTO> menu, int verificationCode, bool accountActive, bool accountSuspended, int postal_code)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.email = email;
            this.password = password;
            this.menu = menu;
            this.verification_code = verificationCode;
            this.account_active = accountActive;
            this.account_suspended = accountSuspended;
            this.postal_code = postal_code;
        }
    }
}
