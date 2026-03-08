using WebApplication2.Models;

namespace WebApplication2.Services.Interface
{
    public interface INotificationService
    {
        Task<List<NotificationModel>> GetUserNotificationsAsync(int userId, bool unreadOnly = false);
        Task<int> GetUnreadCountAsync(int userId);
        Task<NotificationModel> CreateAsync(NotificationModel notification);
        Task MarkAsReadAsync(int notificationId);
        Task MarkAllAsReadAsync(int userId);
        Task DeleteAsync(int notificationId);
        Task CreateLowStockAlertAsync(int businessId, int userId, string productName, int quantity);
        Task CreateSystemNotificationAsync(int userId, string title, string message);
    }
}
