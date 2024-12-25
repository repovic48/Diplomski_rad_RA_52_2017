using Microsoft.AspNetCore.Mvc;
using user_service.Services;
using user_service.Model;

namespace user_service.Controllers;

[ApiController]
[Route("")]
public class UserController : ControllerBase
{
    private readonly IUserService user_service;
    public UserController(IUserService user_service)
    {
        this.user_service = user_service;
    }

    [HttpGet("SayHello")]
    public string SayHello()
    {
        return this.user_service.SayHello();
    }
    
    [HttpPost("registerUser")]
    public async Task<IActionResult> RegisterUser([FromBody] UserDTO userDto)
    {
        if (userDto == null)
        {
            return BadRequest("Invalid user data.");
        }
        try
        {
            var new_user = await user_service.RegisterUser(userDto);
            return CreatedAtAction(nameof(RegisterUser), new { id = new_user.id }, new_user);
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
}
