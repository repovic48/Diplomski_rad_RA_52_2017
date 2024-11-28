using comment_service.Repositories;

namespace comment_service.Services 
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository comment_repository;

        public CommentService(ICommentRepository comment_repository)
        {
            this.comment_repository = comment_repository;
        }

        public string SayHello()
        {
            return this.comment_repository.SayHello();
        }
    }
}
