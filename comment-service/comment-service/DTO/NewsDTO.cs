using System;

namespace comment_service.Model
{
    public class NewsDTO
    {
        public string id { get; set; }
        public string content { get; set; }
        public DateTime date_of_creation { get; set; }

        // Default constructor
        public NewsDTO() { }

        // Constructor to create DTO from News model
        public NewsDTO(News notification)
        {
            this.id = notification.id;
            this.content = notification.content;
            this.date_of_creation = notification.date_of_creation;
        }
    }
}
