using Microsoft.AspNetCore.Mvc;
using user_service.Services;

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
}
