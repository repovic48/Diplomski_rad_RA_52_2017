using order_service.Repositories;
using order_service.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

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

        public async Task<Order> AddOrder(OrderDTO new_orderDTO)
        {
            Order new_order = null;

            try
            {
                new_order = new Order(new_orderDTO)
                {
                    id = Guid.NewGuid().ToString()
                };

                if (!string.IsNullOrEmpty(new_orderDTO.customer_email)) 
                {
                    await SendEmail(
                        new_orderDTO.customer_email,
                        "Potvrda porudžbine",
                        $"Uspešno ste izvršili porudžbinu pod rednim brojem {new_order.id}"
                    );
                }
            }
            catch (Exception ex)
            {
                throw; // Let the stack trace remain intact
            }

            return await this.order_repository.AddOrder(new_order);
        }

        public async Task<Item> AddItem(ItemDTO new_itemDTO)
        {
            Item new_item = new Item(new_itemDTO)
            {
                id = Guid.NewGuid().ToString()
            };

            return await this.order_repository.AddItem(new_item);
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var orders = await this.order_repository.GetAllOrders();

            foreach (var order in orders)
            {
                order.items = await order_repository.GetItemsByOrderId(order.id);
            }

            return orders;
        }

        public async Task<List<Order>> GetOrdersByRestaurantId(string id)
        {
            var orders = await this.order_repository.GetOrdersByRestaurantId(id);

            foreach (var order in orders)
            {
                order.items = await order_repository.GetItemsByOrderId(order.id);
            }

            return orders;
        }

        public async Task<List<Order>> GetOrdersByCustomerEmail(string email)
        {
            var orders = await this.order_repository.GetOrdersByCustomerEmail(email);

            foreach (var order in orders)
            {
                order.items = await order_repository.GetItemsByOrderId(order.id);
            }

            return orders;
        }

        public async Task<bool> DeleteAll()
        {
            return await order_repository.DeleteAll();
        }

        public async Task SendEmail(string recipientEmail, string email_subject, string email_body)
        {
            string sender_email = "narucirs.podrska@gmail.com";
            string sender_password = "whkn gznt iedy bcbt"; // Warning: Store securely

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(sender_email),
                Subject = email_subject,
                Body = email_body
            };
            mailMessage.To.Add(recipientEmail);

            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(sender_email, sender_password);
                smtpClient.EnableSsl = true;

                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                    Console.WriteLine("Email Sent Successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error sending email: " + ex.Message);
                    // Optionally rethrow or handle accordingly
                }
            }
        }
    }
}
