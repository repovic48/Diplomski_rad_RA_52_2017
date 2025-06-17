using order_service.Model;

namespace order_service.Services
{
    public interface IOrderService
    {
        string SayHello();
        public Task<Order> AddOrder(OrderDTO new_orderDTO);
        public Task<Item> AddItem(ItemDTO new_itemDTO);
        public Task<List<Order>> GetAllOrders();
        public Task<List<Order>> GetOrdersByCustomerEmail(string email);
        public Task<List<Order>> GetOrdersByRestaurantId(string id);
    }
}