using System.ComponentModel.DataAnnotations;

namespace order_service.Model
{
    public class Order
    {
        [Key]
        public required string order_id { get; set; }
    }
}