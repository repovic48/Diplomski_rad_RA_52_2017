using System.ComponentModel.DataAnnotations;

namespace user_service.Model
{
    public class Person
    {
        [Key]
        public required string user_id { get; set; }
        public required string name { get; set; }
        public required string surname { get; set; }
        public required string password { get; set; }
        public required string email { get; set; }
        public required string address { get; set; }
        public int postal_code { get; set; }
    }
}