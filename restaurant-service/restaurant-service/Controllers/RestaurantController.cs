using Microsoft.AspNetCore.Mvc;
using restaurant_service.Services;

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
    public string SayHello()
    {
        return this.restaurant_service.SayHello();
    }
}