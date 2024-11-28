using Microsoft.AspNetCore.Mvc;
using comment_service.Services;

namespace comment_service.Controllers;

[ApiController]
[Route("")]
public class CommentController : ControllerBase
{
    private readonly ICommentService comment_service;
    public CommentController(ICommentService comment_service)
    {
        this.comment_service = comment_service;
    }

    [HttpGet("SayHello")]
    public string SayHello()
    {
        return this.comment_service.SayHello();
    }
}
