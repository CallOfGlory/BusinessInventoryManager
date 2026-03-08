using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Interface;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly ApplicationContext _context;

        public BusinessRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<BusinessModel?> GetByIdAsync(int id)
        {
            return await _context.Businesses
                .Include(b => b.Products)
                .Include(b => b.Transactions)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<BusinessModel>> GetByUserIdAsync(int userId)
        {
            return await _context.Businesses
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.IsActive)
                .ThenByDescending(b => b.UpdatedAt)
                .ToListAsync();
        }

        public async Task<BusinessModel?> GetActiveBusinessAsync(int userId)
        {
            return await _context.Businesses
                .Include(b => b.Products)
                .FirstOrDefaultAsync(b => b.UserId == userId && b.IsActive);
        }

        public async Task<BusinessModel> AddAsync(BusinessModel business)
        {
            // If this is the first business, make it active
            var existingBusinesses = await _context.Businesses
                .Where(b => b.UserId == business.UserId)
                .CountAsync();

            if (existingBusinesses == 0)
            {
                business.IsActive = true;
            }

            _context.Businesses.Add(business);
            await _context.SaveChangesAsync();
            return business;
        }

        public async Task<BusinessModel> UpdateAsync(BusinessModel business)
        {
            business.UpdatedAt = DateTime.UtcNow;
            _context.Businesses.Update(business);
            await _context.SaveChangesAsync();
            return business;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var business = await _context.Businesses.FindAsync(id);
            if (business == null) return false;

            _context.Businesses.Remove(business);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SetActiveBusinessAsync(int userId, int businessId)
        {
            // Deactivate all businesses for this user
            var userBusinesses = await _context.Businesses
                .Where(b => b.UserId == userId)
                .ToListAsync();

            foreach (var business in userBusinesses)
            {
                business.IsActive = business.Id == businessId;
                business.UpdatedAt = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
