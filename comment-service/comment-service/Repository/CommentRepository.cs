namespace comment_service.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public string SayHello()
        {
            return "Hello from comment REST microservice :)";
        }
    }
}
