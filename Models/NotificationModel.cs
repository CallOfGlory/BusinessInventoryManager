namespace WebApplication2.Models
{
    public class NotificationModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? BusinessId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public NotificationPriority Priority { get; set; } = NotificationPriority.Normal;
        public string? ActionUrl { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime? ReadAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiresAt { get; set; }

        // Navigation
        public UserModel? User { get; set; }
        public BusinessModel? Business { get; set; }
    }

    public enum NotificationType
    {
        Info = 0,
        Warning = 1,
        Alert = 2,
        Success = 3,
        LowStock = 4,
        NewOrder = 5,
        PaymentDue = 6,
        System = 7
    }

    public enum NotificationPriority
    {
        Low = 0,
        Normal = 1,
        High = 2,
        Urgent = 3
    }
}
