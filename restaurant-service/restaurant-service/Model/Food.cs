namespace restaurant_service.Model
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Food
    {
        [Key]
        public string id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string price { get; set; }

        [Required]
        public string image { get; set; }

        [Required]
        public string restaurant_id { get; set; }

        public bool available { get; set; }

        public int discount { get; set; }

        public Food() { }

        public Food(string id, string name, string price, string image, string restaurant_id, bool available, int discount)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.image = image;
            this.restaurant_id = restaurant_id;
            this.available = available;
            this.discount = discount;
        }

        public Food(FoodDTO foodDTO)
        {
            this.id = foodDTO.id;
            this.name = foodDTO.name;
            this.price = foodDTO.price;
            this.image = foodDTO.image;
            this.restaurant_id = foodDTO.restaurant_id;
            this.discount = foodDTO.discount;
            this.available = foodDTO.available;
        }
    }
}
