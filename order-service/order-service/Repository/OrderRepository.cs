using order_service.Model;
using order_service.DBContext;
using Microsoft.EntityFrameworkCore; // Required for EF Core async methods
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace order_service.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string SayHello()
        {
            return "Hello from order REST microservice :)";
        }

        public async Task<Order> AddOrder(Order new_order)
        {
            if (new_order == null)
                throw new ArgumentNullException(nameof(new_order), "New order cannot be null");

            await context.Orders.AddAsync(new_order);
            await context.SaveChangesAsync();
            return new_order;
        }

        public async Task<Item> AddItem(Item new_item)
        {
            if (new_item == null)
                throw new ArgumentNullException(nameof(new_item), "New item cannot be null");

            await context.Items.AddAsync(new_item);
            await context.SaveChangesAsync();
            return new_item;
        }

        public async Task<List<Item>> GetItemsByOrderId(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty", nameof(id));

            return await context.Items
                .Where(f => f.order_id == id)
                .ToListAsync();
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await context.Orders.ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByCustomerEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));

            return await context.Orders
                .Where(o => o.customer_email == email)
                .ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByRestaurantId(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Restaurant ID cannot be null or empty", nameof(id));

            return await context.Orders
                .Where(o => o.restaurant_id == id)
                .ToListAsync();
        }
    }
}
