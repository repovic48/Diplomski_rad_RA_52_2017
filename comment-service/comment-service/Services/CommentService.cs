using comment_service.Services;

namespace comment_service.Services 
{
    public class CommentService : ICommentService
    {
        public string SayHello()
        {
            return "Hello from comment service :)";
        }
    }
}
