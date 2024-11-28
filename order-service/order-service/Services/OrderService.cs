using order_service.Services;

namespace order_service.Services 
{
    public class OrderService : IOrderService
    {
        public string SayHello()
        {
            return "Hello from order service :)";
        }
    }
}
