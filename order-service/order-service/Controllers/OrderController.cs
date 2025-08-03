using Microsoft.AspNetCore.Mvc;
using order_service.Services;
using order_service.Model;
using Microsoft.AspNetCore.Authorization;

namespace order_service.Controllers;

[ApiController]
[Route("")]
public class OrderController : ControllerBase
{
    private readonly IOrderService order_service;
    public OrderController(IOrderService order_service)
    {
        this.order_service = order_service;
    }

    [HttpGet("SayHello")]
    public string SayHello()
    {
        return this.order_service.SayHello();
    }

    [HttpDelete("deleteAll")]
    public async Task<IActionResult> DeleteAll()
    {
        try
        {
            var deleted = await order_service.DeleteAll();

            return NoContent(); // 204 No Content
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("addOrder")]
    public async Task<IActionResult> AddOrder([FromBody] OrderDTO orderDto)
    {
        if (orderDto == null)
        {
            return BadRequest("Invalid order data.");
        }
        try
        {
            var new_order = await order_service.AddOrder(orderDto);
            return CreatedAtAction(nameof(AddOrder), new { id = new_order.id }, new_order);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("addItem")]
    public async Task<IActionResult> CreateItem([FromBody] ItemDTO itemDto)
    {
        if (itemDto == null)
        {
            return BadRequest("Invalid item data.");
        }
        try
        {
            var new_item = await order_service.AddItem(itemDto);
            return CreatedAtAction(nameof(CreateItem), new { id = new_item.id }, new_item);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("getAllOrders")]
    public async Task<IActionResult> getAllOrders()
    {
        try
        {
            var orders = await order_service.GetAllOrders();

            // If there are no orders, return a 404 Not Found
            if (orders == null || orders.Count == 0)
            {
                return NotFound("No orders found.");
            }

            return Ok(orders);  // Return 200 OK with the list of orders
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("getOrdersByRestaurantId/{id}")]
    public async Task<IActionResult> GetOrdersByRestaurantId(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest("id cannot be null or empty");
        }

        try
        {
            var order = await order_service.GetOrdersByRestaurantId(id);

            if (order == null || order.Count == 0)
            {
                return NotFound("No order found.");
            }

            return Ok(order);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("GetOrdersByCustomerEmail/{email}")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> GetOrdersByCustomerEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return BadRequest("email cannot be null or empty");
        }

        try
        {
            var order = await order_service.GetOrdersByCustomerEmail(email);

            if (order == null || order.Count == 0)
            {
                return NotFound("No order found.");
            }

            return Ok(order);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
