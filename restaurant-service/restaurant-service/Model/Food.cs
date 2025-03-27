namespace restaurant_service.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
        public string restourant_id { get; set; }
        
        public Food() { }

        public Food(string id, string name, string price, string image, string restourant_id)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.image = image;
            this.restourant_id = restourant_id;
        }

        public Food(FoodDTO foodDTO)
        {
            this.id = foodDTO.id;
            this.name = foodDTO.name;
            this.price = foodDTO.price;
            this.image = foodDTO.image;
            this.restourant_id = foodDTO.restaurant_id;
        }
    }
}
