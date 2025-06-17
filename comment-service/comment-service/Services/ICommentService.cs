using comment_service.Model;

namespace comment_service.Services
{
    public interface ICommentService
    {
        string SayHello();
        public Task<Comment> AddComment(CommentDTO new_commentDTO);
        public Task<List<Comment>> GetCommentsByRestaurantId(string id);
        public Task<List<Comment>> GetAllComments();
        public Task<Comment?> UpdateComment(string id, CommentDTO updatedCommentDto);
        public Task<bool> DeleteComment(string id);
    }
}