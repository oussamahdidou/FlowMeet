using System.ComponentModel.DataAnnotations;

namespace FlowMeet.Notification.Domain.Entities
{
    public class NotificationTemplate
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Label { get; set; }
        public string Content { get; set; }
        public ICollection<Message> Notifications { get; set; }
    }
}
