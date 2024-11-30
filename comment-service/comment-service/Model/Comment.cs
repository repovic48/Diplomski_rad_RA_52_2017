using System.ComponentModel.DataAnnotations;

namespace comment_service.Model
{
    public class Comment
    {
        [Key]
        public string comment_id { get; set; }
        public string author { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
    }
}
