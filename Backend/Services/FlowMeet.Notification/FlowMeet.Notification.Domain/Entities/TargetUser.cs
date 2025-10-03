using System.ComponentModel.DataAnnotations;

namespace FlowMeet.Notification.Domain.Entities
{
    public class TargetUser
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<UserNotification> UserNotifications { get; set; }
    }
}
