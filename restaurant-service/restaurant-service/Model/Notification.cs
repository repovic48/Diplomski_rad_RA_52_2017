namespace restaurant_service.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Notification
    {
        [Key]
        public string id { get; set; }

        [Required]
        public string subject { get; set; }

        [Required]
        public string content { get; set; }

        [Required]
        public DateTime date_of_creation { get; set; }

        [Required]
        public string restaurant_id { get; set; }

        public Notification() { }

        public Notification(string id, string subject, string content, string restaurant_id)
        {
            this.id = id;
            this.subject = subject;
            this.content = content;
            this.date_of_creation = DateTime.UtcNow;
            this.restaurant_id = restaurant_id;
        }

        public Notification(NotificationDTO dto)
        {
            this.id = dto.id;
            this.subject = dto.subject;
            this.content = dto.content;
            this.date_of_creation = dto.date_of_creation;
            this.restaurant_id = dto.restaurant_id;
        }
    }
}
