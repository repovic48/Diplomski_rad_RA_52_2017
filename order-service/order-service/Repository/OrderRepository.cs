namespace order_service.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public string SayHello()
        {
            return "Hello from order REST microservice :)";
        }
    }
}
