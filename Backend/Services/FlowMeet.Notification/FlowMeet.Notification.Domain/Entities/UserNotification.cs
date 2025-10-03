namespace FlowMeet.Notification.Domain.Entities
{
    public class UserNotification
    {
        public string TargetUserId { get; set; }
        public TargetUser TargetUser { get; set; }
        public string MessageId { get; set; }
        public Message Message { get; set; }
    }
}
