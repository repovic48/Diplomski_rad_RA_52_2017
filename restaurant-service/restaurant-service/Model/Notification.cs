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
        public string restaurant_email { get; set; }

        public Notification() { }

        public Notification(string id, string subject, string content, string restaurant_email)
        {
            this.id = id;
            this.subject = subject;
            this.content = content;
            this.date_of_creation = DateTime.UtcNow;
            this.restaurant_email = restaurant_email;
        }

        public Notification(NotificationDTO dto)
        {
            this.id = dto.id;
            this.subject = dto.subject;
            this.content = dto.content;
            this.date_of_creation = dto.date_of_creation;
            this.restaurant_email = dto.restaurant_email;
        }
    }
}
