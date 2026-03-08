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

        public async Task<BusinessModel> AddAsync(BusinessModel business)
        {
            await _context.Businesses.AddAsync(business);
            await _context.SaveChangesAsync();
            return business;
        }

        public async Task<BusinessModel?> GetByIdAsync(int id)
        {
            return await _context.Businesses
                .Include(b => b.Products)
                .Include(b => b.Transactions)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<BusinessModel>> GetByUserIdAsync(int userId)
        {
            return await _context.Businesses
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();
        }

        public async Task UpdateAsync(BusinessModel business)
        {
            _context.Businesses.Update(business);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var business = await _context.Businesses.FindAsync(id);
            if (business != null)
            {
                _context.Businesses.Remove(business);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id, int userId)
        {
            return await _context.Businesses.AnyAsync(b => b.Id == id && b.UserId == userId);
        }
    }
}
