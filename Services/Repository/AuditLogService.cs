using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services.Interface;

namespace WebApplication2.Services.Repository
{
    public class AuditLogService : IAuditLogService
    {
        private readonly ApplicationContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditLogService(ApplicationContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task LogAsync(int userId, string action, string entityType, int? entityId = null,
            object? oldValues = null, object? newValues = null, int? businessId = null)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            
            var log = new AuditLogModel
            {
                UserId = userId,
                BusinessId = businessId,
                Action = action,
                EntityType = entityType,
                EntityId = entityId,
                OldValues = oldValues != null ? JsonSerializer.Serialize(oldValues) : null,
                NewValues = newValues != null ? JsonSerializer.Serialize(newValues) : null,
                IpAddress = httpContext?.Connection?.RemoteIpAddress?.ToString(),
                UserAgent = httpContext?.Request?.Headers["User-Agent"].ToString(),
                Timestamp = DateTime.UtcNow
            };

            _context.Set<AuditLogModel>().Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AuditLogModel>> GetLogsAsync(int businessId, DateTime? from = null, DateTime? to = null)
        {
            var query = _context.Set<AuditLogModel>()
                .Include(l => l.User)
                .Where(l => l.BusinessId == businessId);

            if (from.HasValue)
                query = query.Where(l => l.Timestamp >= from.Value);
            if (to.HasValue)
                query = query.Where(l => l.Timestamp <= to.Value);

            return await query.OrderByDescending(l => l.Timestamp).Take(500).ToListAsync();
        }

        public async Task<List<AuditLogModel>> GetUserLogsAsync(int userId, int count = 50)
        {
            return await _context.Set<AuditLogModel>()
                .Where(l => l.UserId == userId)
                .OrderByDescending(l => l.Timestamp)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<AuditLogModel>> GetEntityLogsAsync(string entityType, int entityId)
        {
            return await _context.Set<AuditLogModel>()
                .Include(l => l.User)
                .Where(l => l.EntityType == entityType && l.EntityId == entityId)
                .OrderByDescending(l => l.Timestamp)
                .ToListAsync();
        }
    }
}
