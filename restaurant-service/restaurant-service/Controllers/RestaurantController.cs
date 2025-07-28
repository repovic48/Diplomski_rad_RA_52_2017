using Microsoft.AspNetCore.Mvc;
using restaurant_service.Services;
using restaurant_service.Model;
using Microsoft.AspNetCore.Authorization;

namespace restaurant_service.Controllers;

[ApiController]
[Route("")]
public class RestaurantController : ControllerBase
{
    private readonly IRestaurantService restaurant_service;
    public RestaurantController(IRestaurantService restaurant_service)
    {
        this.restaurant_service = restaurant_service;
    }

    [HttpGet("SayHello")]
    [Authorize(Roles = "Restaurant")]
    public string SayHello()
    {
        return this.restaurant_service.SayHello();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RestaurantDTO restaurantDto)
    {
        if (restaurantDto == null)
        {
            return BadRequest("Invalid restaurant data.");
        }
        try
        {
            var new_restaurant = await restaurant_service.Register(restaurantDto);
            return CreatedAtAction(nameof(Register), new { id = new_restaurant.id }, new_restaurant);
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

    [HttpPost("addFood")]
    public async Task<IActionResult> AddFood([FromBody] FoodDTO foodDto)
    {
        if (foodDto == null)
        {
            return BadRequest("Invalid restaurant data.");
        }
        try
        {
            var new_food = await restaurant_service.AddFood(foodDto);
            return CreatedAtAction(nameof(AddFood), new { id = new_food.id }, new_food);
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

    [HttpPost("createNotification")]
    public async Task<IActionResult> CreateNotification([FromBody] NotificationDTO notificationDto)
    {
        if (notificationDto == null)
        {
            return BadRequest("Invalid restaurant data.");
        }
        try
        {
            var new_notification = await restaurant_service.CreateNotification(notificationDto);
            return CreatedAtAction(nameof(CreateNotification), new { id = new_notification.id }, new_notification);
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

    [HttpGet("getAllNotifications")]
    public async Task<IActionResult> GetAllNotifications()
    {
        try
        {
            var notifications = await restaurant_service.GetAllNotifications();

            // If there are no notifications, return a 404 Not Found
            if (notifications == null || notifications.Count == 0)
            {
                return NotFound("No notifications found.");
            }
            
            return Ok(notifications);  // Return 200 OK with the list of notifications
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("notifyUsers/{notification_id}")]
    public async Task<IActionResult> NotifyUsers(
        [FromRoute] string notification_id,
        [FromBody] List<string> emails)
    {
        try
        {
            await restaurant_service.NotifyUsers(notification_id, emails);
            return Ok(emails);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }


    [HttpGet("getAllRestaurants")]
    public async Task<IActionResult> GetAllRestaurants()
    {
        try
        {
            var restaurants = await restaurant_service.GetAllRestaurants();

            // If there are no restaurants, return a 404 Not Found
            if (restaurants == null || restaurants.Count == 0)
            {
                return NotFound("No restaurants found.");
            }
            
            return Ok(restaurants);  // Return 200 OK with the list of restaurants
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("getAllFoods")]
    public async Task<IActionResult> GetAllFoods()
    {
        try
        {
            var food = await restaurant_service.GetAllFoods();

            // If there are no restaurants, return a 404 Not Found
            if (food == null || food.Count == 0)
            {
                return NotFound("No food found.");
            }
            
            return Ok(food);  // Return 200 OK with the list of restaurants
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("delete/{email}")]
    public async Task<IActionResult> DeleteRestaurantByEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return BadRequest("Email cannot be null or empty");
        }

        var result = await restaurant_service.DeleteRestaurantByEmail(email);

        if (result)
        {
            return Ok($"Restaurant with email {email} deleted successfully.");
        }
        else
        {
            return NotFound($"Restaurant with email {email} not found.");
        }
    }

    [HttpDelete("deleteFood/{id}")]
    public async Task<IActionResult> DeleteFoodById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest("id cannot be null or empty");
        }

        var result = await restaurant_service.DeleteFoodById(id);

        if (result)
        {
            return Ok($"Food with id {id} deleted successfully.");
        }
        else
        {
            return NotFound($"Food with id {id} not found.");
        }
    }

    [HttpDelete("deleteNotification/{id}")]
    public async Task<IActionResult> DeleteNotificationById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest("id cannot be null or empty");
        }

        var result = await restaurant_service.DeleteNotificationById(id);

        if (result)
        {
            return Ok($"Notification with id {id} deleted successfully.");
        }
        else
        {
            return NotFound($"Notification with id {id} not found.");
        }
    }

    [HttpGet("getFoodsByRestaurantId/{id}")]
    public async Task<IActionResult> GetFoodsByRestaurantId(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest("id cannot be null or empty");
        }

        try
        {
            var food = await restaurant_service.GetFoodsByRestaurantId(id);

            if (food == null || food.Count == 0)
            {
                return NotFound("No food found.");
            }
            
            return Ok(food); 
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }


    [HttpGet("getFoodById/{id}")]
    public async Task<IActionResult> GetFoodById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest("id cannot be null or empty");
        }

        try
        {
            var food = await restaurant_service.GetFoodById(id);

            if (food == null)
            {
                return NotFound("No food found.");
            }
            
            return Ok(food); 
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("getRestaurantById/{id}")]
    public async Task<IActionResult> GetRestaurantById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest("id cannot be null or empty");
        }

        try
        {
            var restraurant = await restaurant_service.GetRestaurantById(id);

            if (restraurant == null)
            {
                return NotFound("No restraurant found.");
            }
            
            return Ok(restraurant); 
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("getFoodById/{id}")]
    public async Task<IActionResult> getFoodById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest("id cannot be null or empty");
        }

        try
        {
            var food = await restaurant_service.GetFoodById(id);

            if (food == null)
            {
                return NotFound("No food found.");
            }
            
            return Ok(food); 
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("getRestaurantByEmail/{email}")]
    public async Task<IActionResult> GetRestaurantByEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return BadRequest("email cannot be null or empty");
        }

        try
        {
            var restraurant = await restaurant_service.GetRestaurantByEmail(email);

            if (restraurant == null)
            {
                return NotFound("No restraurant found.");
            }
            
            return Ok(restraurant); 
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] RestaurantDTO restarurantDto)
    {
        if (restarurantDto == null)
        {
            return BadRequest("Invalid restaurant data.");
        }

        try
        {
            var existingRestaurant = await restaurant_service.Login(restarurantDto);

            if (existingRestaurant == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok(existingRestaurant); 
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

    [HttpPut("verify")]
    public async Task<IActionResult> VerifyAccount([FromBody] RestaurantDTO restaurantDTO)
    {
        if (restaurantDTO == null)
        {
            return BadRequest("Restaurant data cannot be null.");
        }

        var verifiedRestaurant = await restaurant_service.VerifyAccount(restaurantDTO);
        if (verifiedRestaurant == null)
        {
            return NotFound("Restaurant not found or verification failed.");
        }

        return Ok(verifiedRestaurant);
    }

    [HttpPut("updateFood")]
    public async Task<IActionResult> UpdateFood([FromBody] FoodDTO foodDTO)
    {
        if (foodDTO == null)
        {
            return BadRequest("Food data cannot be null.");
        }

        var verifiedFood = await restaurant_service.UpdateFood(foodDTO);
        if (verifiedFood == null)
        {
            return NotFound("Food not found.");
        }

        return Ok(verifiedFood);
    }

    [HttpPut("updateRestaurant")]
    public async Task<IActionResult> UpdateRestaurant([FromBody] RestaurantDTO restaurantDTO)
    {
        if (restaurantDTO == null)
        {
            return BadRequest("Restaurant data cannot be null.");
        }

        var verifiedRestaurant = await restaurant_service.UpdateRestaurant(restaurantDTO);
        if (verifiedRestaurant == null)
        {
            return NotFound("Restaurant not found.");
        }

        return Ok(verifiedRestaurant);
    }
}
