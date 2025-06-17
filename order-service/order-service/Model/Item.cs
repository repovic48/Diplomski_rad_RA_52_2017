using System.ComponentModel.DataAnnotations;

namespace order_service.Model
{
    public class Item
    {
        [Key]
        public string id { get; set; }

        [Required]
        public string food { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        public double price { get; set; }

        [Required]
        public string order_id { get; set; }

        // Parameterless constructor
        public Item() { }

        // Constructor with parameters
        public Item(string id, string food, int quantity, double price, string order_id)
        {
            this.id = id;
            this.food = food;
            this.quantity = quantity;
            this.price = price;
            this.order_id = order_id;
        }

        // Constructor from DTO
        public Item(ItemDTO dto)
        {
            id = dto.id;
            food = dto.food;
            quantity = dto.quantity;
            price = dto.price;
            order_id = dto.order_id;
        }
    }
}
