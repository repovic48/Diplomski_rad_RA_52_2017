namespace order_service.Model
{
    public class ItemDTO
    {
        public string id { get; set; }

        public string food { get; set; }
        
        public int quantity { get; set; }

        public double price { get; set; }

        public string order_id { get; set; }

        public ItemDTO() { }

        public ItemDTO(string id, string food, int quantity, double price, string order_id)
        {
            this.id = id;
            this.food = food;
            this.quantity = quantity;
            this.price = price;
            this.order_id = order_id;
        }
    }
}
