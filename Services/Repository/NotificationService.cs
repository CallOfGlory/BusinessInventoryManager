using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services.Interface;

namespace WebApplication2.Services.Repository
{
    public class NotificationService : INotificationService
    {
        private readonly ApplicationContext _context;

        public NotificationService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<NotificationModel>> GetUserNotificationsAsync(int userId, bool unreadOnly = false)
        {
            var query = _context.Set<NotificationModel>()
                .Where(n => n.UserId == userId && (n.ExpiresAt == null || n.ExpiresAt > DateTime.UtcNow));
            
            if (unreadOnly)
                query = query.Where(n => !n.IsRead);

            return await query.OrderByDescending(n => n.CreatedAt).Take(50).ToListAsync();
        }

        public async Task<int> GetUnreadCountAsync(int userId)
        {
            return await _context.Set<NotificationModel>()
                .CountAsync(n => n.UserId == userId && !n.IsRead);
        }

        public async Task<NotificationModel> CreateAsync(NotificationModel notification)
        {
            notification.CreatedAt = DateTime.UtcNow;
            _context.Set<NotificationModel>().Add(notification);
            await _context.SaveChangesAsync();
            return notification;
        }

        public async Task MarkAsReadAsync(int notificationId)
        {
            var notification = await _context.Set<NotificationModel>().FindAsync(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                notification.ReadAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task MarkAllAsReadAsync(int userId)
        {
            var notifications = await _context.Set<NotificationModel>()
                .Where(n => n.UserId == userId && !n.IsRead)
                .ToListAsync();

            foreach (var n in notifications)
            {
                n.IsRead = true;
                n.ReadAt = DateTime.UtcNow;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int notificationId)
        {
            var notification = await _context.Set<NotificationModel>().FindAsync(notificationId);
            if (notification != null)
            {
                _context.Set<NotificationModel>().Remove(notification);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateLowStockAlertAsync(int businessId, int userId, string productName, int quantity)
        {
            await CreateAsync(new NotificationModel
            {
                UserId = userId,
                BusinessId = businessId,
                Title = "Low Stock Alert",
                Message = $"{productName} is running low. Only {quantity} units left.",
                Type = NotificationType.LowStock,
                Priority = NotificationPriority.High,
                ActionUrl = "/Products"
            });
        }

        public async Task CreateSystemNotificationAsync(int userId, string title, string message)
        {
            await CreateAsync(new NotificationModel
            {
                UserId = userId,
                Title = title,
                Message = message,
                Type = NotificationType.System,
                Priority = NotificationPriority.Normal
            });
        }
    }
}
