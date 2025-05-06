namespace restaurant_service.Model
{
    using System;

    public class NotificationDTO
    {
        public string id { get; set; }
        public string subject { get; set; }
        public string content { get; set; }
        public DateTime date_of_creation { get; set; }
        public string restaurant_id { get; set; }

        public NotificationDTO() { }

        public NotificationDTO(string id, string subject, string content, DateTime date_of_creation, string restaurant_id)
        {
            this.id = id;
            this.subject = subject;
            this.content = content;
            this.date_of_creation = date_of_creation;
            this.restaurant_id = restaurant_id;
        }
    }
}
