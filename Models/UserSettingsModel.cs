namespace WebApplication2.Models
{
    public class UserSettingsModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Theme { get; set; } = "light";
        public string Language { get; set; } = "en";
        public bool EmailNotifications { get; set; } = true;
        public bool LowStockAlerts { get; set; } = true;
        public int LowStockThreshold { get; set; } = 10;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public UserModel? User { get; set; }
    }
}
