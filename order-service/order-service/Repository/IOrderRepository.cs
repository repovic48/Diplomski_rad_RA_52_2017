using order_service.Model;

namespace order_service.Repositories
{
    public interface IOrderRepository
    {
        string SayHello();
        public Task<Order> AddOrder(Order new_order);
        public Task<Item> AddItem(Item new_item);
        public Task<List<Item>> GetItemsByOrderId(string id);
        public Task<List<Order>> GetAllOrders();
        public Task<List<Order>>  GetOrdersByCustomerEmail(string email);
        public Task<List<Order>> GetOrdersByRestaurantId(string id);
    }
}