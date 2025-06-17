using System;
using System.Collections.Generic;
using order_service.Model;

namespace order_service.Model
{
    public class OrderDTO
    {
        public string id { get; set; }

        public List<ItemDTO> items { get; set; }

        public string? customer_email { get; set; }

        public string restaurant_id { get; set; }

        public DateTime date_of_creation { get; set; }

        public double total_price { get; set; }

        public string address { get; set; }

        public int postal_code { get; set; }

        public OrderDTO(string id, string? customer_email, DateTime date_of_creation, double total_price, string restaurant_id, string address, int postal_code)
        {
            this.id = id;
            this.items = new List<ItemDTO>();
            this.customer_email = customer_email;
            this.date_of_creation = date_of_creation;
            this.total_price = total_price;
            this.restaurant_id = restaurant_id;
            this.address = address;
            this.postal_code = postal_code;
        }

        public OrderDTO() {}
    }
}
