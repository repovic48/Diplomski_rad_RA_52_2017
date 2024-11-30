using System.ComponentModel.DataAnnotations;

namespace restaurant_service.Model
{
    public class Restaurant
    {
        [Key]
        public required string restourant_id { get; set; }
        public required string name { get; set; }
        public required string address { get; set; }
    }
}