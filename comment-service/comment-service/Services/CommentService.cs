using comment_service.Repositories;
using comment_service.Model;

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

        public async Task<List<Comment>> GetCommentsByRestaurantId(string id)
        {
            return await this.comment_repository.GetCommentsByRestaurantId(id);
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await this.comment_repository.GetAllComments();
        }

        public async Task<Comment> AddComment(CommentDTO new_commentDTO)
        {
            Comment new_comment = new Comment(new_commentDTO)
            {
                id = Guid.NewGuid().ToString()
            };

            return await this.comment_repository.AddComment(new_comment);
        }

        public async Task<Comment?> UpdateComment(string id, CommentDTO updatedCommentDto)
        {
            var existingComment = await comment_repository.GetCommentById(id);

            if (existingComment == null)
                return null;

            // Update fields
            existingComment.author = updatedCommentDto.author;
            existingComment.author_email = updatedCommentDto.author_email;
            existingComment.restaurant_id = updatedCommentDto.restaurant_id;
            existingComment.restaurant_rating = updatedCommentDto.restaurant_rating;
            existingComment.comment_rating = updatedCommentDto.comment_rating;
            existingComment.users_that_rated_comment = updatedCommentDto.users_that_rated_comment ?? new List<string>();
            existingComment.content = updatedCommentDto.content;
            existingComment.date = updatedCommentDto.date;
            existingComment.reply_to = updatedCommentDto.reply_to;
            existingComment.deleted = updatedCommentDto.deleted;
            existingComment.delete_requested = updatedCommentDto.delete_requested;

            return await comment_repository.UpdateComment(existingComment);
        }

        public async Task<bool> DeleteComment(string id)
        {
            return await comment_repository.DeleteComment(id);
        }

        public async Task<News> AddNews(NewsDTO newsDto)
        {
            News new_news = new News(newsDto)
            {
                id = Guid.NewGuid().ToString()
            };

            return await this.comment_repository.AddNews(new_news);
        }

        public async Task<bool> DeleteNews(string id)
        {
            return await comment_repository.DeleteNews(id);
        }
        public async Task<List<News>> GetAllNews()
        {
            return await this.comment_repository.GetAllNews();
        }

    }
}
