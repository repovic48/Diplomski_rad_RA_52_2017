using comment_service.Model;
using comment_service.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace comment_service.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext context;

        public CommentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string SayHello()
        {
            return "Hello from comment REST microservice :)";
        }

        public async Task<Comment> AddComment(Comment new_comment)
        {
            if (new_comment == null)
                throw new ArgumentNullException(nameof(new_comment), "New comment cannot be null");

            await context.Comments.AddAsync(new_comment);
            await context.SaveChangesAsync();
            return new_comment;
        }

        public async Task<List<Comment>> GetCommentsByRestaurantId(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Restaurant ID cannot be null or empty", nameof(id));

            return await context.Comments
                .Where(c => c.restaurant_id == id)
                .ToListAsync();
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetCommentById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Comment ID cannot be null or empty", nameof(id));

            return await context.Comments.FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<Comment> UpdateComment(Comment updatedComment)
        {
            if (updatedComment == null)
                throw new ArgumentNullException(nameof(updatedComment), "Updated comment cannot be null");

            context.Comments.Update(updatedComment);
            await context.SaveChangesAsync();
            return updatedComment;
        }

        public async Task<bool> DeleteComment(string id)
        {
            var comment = await context.Comments.FirstOrDefaultAsync(c => c.id == id);
            if (comment == null)
                return false;

            context.Comments.Remove(comment);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
