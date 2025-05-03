namespace restaurant_service.Model
{
    public class FoodDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public string restaurant_id { get; set; }
        public bool available { get; set; }
        public int discount { get; set; }
        public FoodDTO() { }

        public FoodDTO(string id, string name, string price, string image, string restaurantId, bool available, int discount)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.image = image;
            this.restaurant_id = restaurantId;
            this.discount = discount;
            this.available = available;
        }
    }
}
