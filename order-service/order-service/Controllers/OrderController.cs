using Microsoft.AspNetCore.Mvc;
using order_service.Services;

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
}
