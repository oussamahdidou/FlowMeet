using System.ComponentModel.DataAnnotations;

namespace FlowMeet.Notification.Domain.Entities
{
    public class Message
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
        public string Content { get; set; }
        public string NotificationTemplateId { get; set; }
        public NotificationTemplate NotificationTemplate { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
