namespace comment_service.Model
{
    public class CommentDTO
    {
        public string id { get; set; }
        public string author { get; set; }
        public string restaurant_id { get; set; } 
        public string author_email { get; set; }
        public float restaurant_rating { get; set; }
        public int comment_rating { get; set; }
        public List<string> users_that_rated_comment { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
        public string reply_to { get; set; }
        public bool delete_requested { get; set; }
        public bool deleted{ get; set; }
        // Default constructor
        public CommentDTO() { }

        // Constructor to create DTO from a Comment model
        public CommentDTO(Comment comment)
        {
            this.id = comment.id;
            this.author = comment.author;
            this.restaurant_id = comment.restaurant_id;
            this.author_email = comment.author_email;
            this.restaurant_rating = comment.restaurant_rating;
            this.comment_rating = comment.comment_rating;
            this.users_that_rated_comment = comment.users_that_rated_comment;
            this.content = comment.content;
            this.date = comment.date;
            this.reply_to = comment.reply_to;
            this.delete_requested = comment.delete_requested;
            this.deleted = comment.deleted;
        }
    }
}
