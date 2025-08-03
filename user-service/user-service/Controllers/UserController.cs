using Microsoft.AspNetCore.Mvc;
using user_service.Services;
using user_service.Model;
using Microsoft.AspNetCore.Authorization;

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
    [Authorize(Roles = "User")]
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

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserDTO userDto)
    {
        if (userDto == null)
        {
            return BadRequest("Invalid user data.");
        }

        try
        {
            var existingUser = await user_service.Login(userDto);

            if (existingUser == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok(existingUser); 
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

    [HttpGet("getAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            var users = await user_service.GetAllUsers();

            // If there are no users, return a 404 Not Found
            if (users == null || users.Count == 0)
            {
                return NotFound("No users found.");
            }
            
            return Ok(users);  // Return 200 OK with the list of users
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("getAllEmails")]
    [Authorize(Roles = "Restaurant")]
    public async Task<IActionResult> GetAllEmails()
    {
        try
        {
            var emails = await user_service.GetAllEmails();

            // If there are no emails, return a 404 Not Found
            if (emails == null || emails.Count == 0)
            {
                return NotFound("No users found.");
            }

            return Ok(emails);  // Return 200 OK with the list of emails
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("delete/{email}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteUserByEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return BadRequest("Email cannot be null or empty");
        }

        var result = await user_service.DeleteUserByEmail(email);

        if (result)
        {
            return Ok($"User with email {email} deleted successfully.");
        }
        else
        {
            return NotFound($"User with email {email} not found.");
        }
    }

    [HttpGet("getByEmail/{email}")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return BadRequest("Email cannot be null or empty");
        }

        var user = await user_service.GetUserByEmail(email);

        if (user != null)
        {
            return Ok(user);
        }
        else
        {
            return NotFound($"User with email {email} not found.");
        }
    }

    [HttpPut("update")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> UpdateUser([FromBody] UserDTO userDTO)
    {
        if (userDTO == null)
        {
            return BadRequest("User data cannot be null.");
        }

        var updatedUser = await user_service.UpdateUser(userDTO);
        if (updatedUser == null)
        {
            return NotFound("User not found or unable to update.");
        }

        return Ok(updatedUser);
    }

    [HttpPut("verify")]
    [Authorize]
    public async Task<IActionResult> VerifyAccount([FromBody] UserDTO userDTO)
    {
        if (userDTO == null)
        {
            return BadRequest("User data cannot be null.");
        }

        var verifiedUser = await user_service.VerifyAccount(userDTO);
        if (verifiedUser == null)
        {
            return NotFound("User not found or verification failed.");
        }

        return Ok(verifiedUser);
    }

}
