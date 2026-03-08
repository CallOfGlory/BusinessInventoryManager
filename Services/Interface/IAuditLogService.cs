using WebApplication2.Models;

namespace WebApplication2.Services.Interface
{
    public interface IAuditLogService
    {
        Task LogAsync(int userId, string action, string entityType, int? entityId = null, 
            object? oldValues = null, object? newValues = null, int? businessId = null);
        Task<List<AuditLogModel>> GetLogsAsync(int businessId, DateTime? from = null, DateTime? to = null);
        Task<List<AuditLogModel>> GetUserLogsAsync(int userId, int count = 50);
        Task<List<AuditLogModel>> GetEntityLogsAsync(string entityType, int entityId);
    }
}
