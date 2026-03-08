namespace WebApplication2.Models
{
    public class AuditLogModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? BusinessId { get; set; }
        public string Action { get; set; } = string.Empty; // Create, Update, Delete, Login, etc.
        public string EntityType { get; set; } = string.Empty; // Product, Transaction, User, etc.
        public int? EntityId { get; set; }
        public string? OldValues { get; set; } // JSON of old values
        public string? NewValues { get; set; } // JSON of new values
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // Navigation
        public UserModel? User { get; set; }
        public BusinessModel? Business { get; set; }
    }
}
