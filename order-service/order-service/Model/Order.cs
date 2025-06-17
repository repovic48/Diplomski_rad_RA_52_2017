using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace order_service.Model
{
    public class Order
    {
        [Key]
        public string id { get; set; }

        public List<Item> items { get; set; } = new List<Item>();

        public string? customer_email { get; set; }
        
        public string restaurant_id { get; set; }

        [Required]
        public DateTime date_of_creation { get; set; }

        [Required]
        public double total_price { get; set; }

        public string address { get; set; }
        public int postal_code { get; set; }

        public Order() { }

        public Order(string id, string? customer_email, DateTime date_of_creation, double total_price, string restaurant_id, string address, int postal_code)
        {
            this.id = id;
            this.customer_email = customer_email;
            this.date_of_creation = date_of_creation;
            this.total_price = total_price;
            this.items = new List<Item>();
            this.restaurant_id = restaurant_id;
            this.address = address;
            this.postal_code = postal_code;
        }

        public Order(OrderDTO dto)
        {
            id = dto.id;
            items = dto.items.Select(f => new Item(f)).ToList();
            customer_email = dto.customer_email;
            date_of_creation = dto.date_of_creation;
            total_price = dto.total_price;
            restaurant_id = dto.restaurant_id;
            address = dto.address;
            postal_code = dto.postal_code;
        }
    }
}
