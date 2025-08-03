using System;
using System.ComponentModel.DataAnnotations;

namespace comment_service.Model
{
    public class News
    {
        [Key]
        public string id { get; set; }
        public string content { get; set; }
        public DateTime date_of_creation { get; set; }

        public News()
        {
            this.id = Guid.NewGuid().ToString();
            this.date_of_creation = DateTime.UtcNow;
        }

        public News(string content)
        {
            this.id = Guid.NewGuid().ToString();
            this.content = content;
            this.date_of_creation = DateTime.UtcNow;
        }

        public News(string id, string content, DateTime date_of_creation)
        {
            this.id = id;
            this.content = content;
            this.date_of_creation = date_of_creation;
        }

        public News(NewsDTO dto)
        {
            this.id = string.IsNullOrEmpty(dto.id) ? Guid.NewGuid().ToString() : dto.id;
            this.content = dto.content;
            this.date_of_creation = dto.date_of_creation == default(DateTime)
                ? DateTime.UtcNow
                : dto.date_of_creation;
        }
    }
}
