namespace comment_service.Model
{
    public class CommentDTO
    {
        public string author { get; set; }
        public string restaurant_id { get; set; } // <-- Added
        public string author_email { get; set; }
        public int restaurant_rating { get; set; }
        public int comment_rating { get; set; }
        public List<string> users_that_rated_comment { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }

        // Default constructor
        public CommentDTO() { }

        // Constructor to create DTO from a Comment model
        public CommentDTO(Comment comment)
        {
            this.author = comment.author;
            this.restaurant_id = comment.restaurant_id; // <-- Added
            this.author_email = comment.author_email;
            this.restaurant_rating = comment.restaurant_rating;
            this.comment_rating = comment.comment_rating;
            this.users_that_rated_comment = comment.users_that_rated_comment;
            this.content = comment.content;
            this.date = comment.date;
        }
    }
}
