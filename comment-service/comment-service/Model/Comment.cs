using System.ComponentModel.DataAnnotations;

namespace comment_service.Model
{
    public class Comment
    {
        [Key]
        public string id { get; set; }
        public string author { get; set; }
        public string restaurant_id { get; set; }
        public string author_email { get; set; }
        public string reply_to { get; set; }
        public float restaurant_rating { get; set; }
        public int comment_rating { get; set; }
        public List<string> users_that_rated_comment { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
        public bool delete_requested { get; set; }
        public bool deleted{ get; set; }

        // Default constructor
        public Comment()
        {
            this.delete_requested = false;
        }

        // Constructor to create Comment from DTO
        public Comment(CommentDTO dto)
        {
            this.id = Guid.NewGuid().ToString();
            this.author = dto.author;
            this.restaurant_id = dto.restaurant_id;
            this.author_email = dto.author_email;
            this.restaurant_rating = dto.restaurant_rating;
            this.comment_rating = dto.comment_rating;
            this.users_that_rated_comment = dto.users_that_rated_comment ?? new List<string>();
            this.content = dto.content;
            this.date = dto.date;
            this.reply_to = dto.reply_to;
            this.delete_requested = dto.delete_requested;
            this.deleted = dto.deleted;
        }

        // Constructor with parameters
        public Comment(
            string id,
            string author,
            string restaurant_id,
            string author_email,
            float restaurant_rating,
            int comment_rating,
            string content,
            DateTime date,
            string reply_to,
            bool delete_requested,
            bool deleted
        )
        {
            this.id = id;
            this.author = author;
            this.restaurant_id = restaurant_id;
            this.author_email = author_email;
            this.restaurant_rating = restaurant_rating;
            this.comment_rating = comment_rating;
            this.users_that_rated_comment = new List<string>();
            this.content = content;
            this.date = date;
            this.reply_to = reply_to;
            this.delete_requested = delete_requested;
            this.deleted = deleted;
        }
    }
}
