using order_service.Repositories;

namespace order_service.Services 
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository order_repository;

        public OrderService(IOrderRepository order_repository)
        {
            this.order_repository = order_repository;
        }
        public string SayHello()
        {
            return this.order_repository.SayHello();
        }
    }
}
