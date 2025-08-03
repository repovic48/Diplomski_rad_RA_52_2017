using comment_service.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace comment_service.Repositories
{
    public interface ICommentRepository
    {
        string SayHello();
        Task<Comment> AddComment(Comment new_comment);
        Task<List<Comment>> GetCommentsByRestaurantId(string id);
        Task<List<Comment>> GetAllComments();
        Task<Comment?> GetCommentById(string id);
        Task<Comment> UpdateComment(Comment updatedComment);
        Task<bool> DeleteComment(string id);
        Task<News> AddNews(News newsDto);
        Task<bool> DeleteNews(string id);
        Task<List<News>> GetAllNews();
    }
}
