using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Interface;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationContext _context;

        public TransactionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<TransactionModel> AddAsync(TransactionModel transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<TransactionModel?> GetByIdAsync(int id)
        {
            return await _context.Transactions
                .Include(t => t.Product)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<TransactionModel>> GetByBusinessIdAsync(int businessId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId);

            if (startDate.HasValue)
                query = query.Where(t => t.TransactionDate >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(t => t.TransactionDate <= endDate.Value);

            return await query
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }

        public async Task<List<TransactionModel>> GetByProductIdAsync(int productId)
        {
            return await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.ProductId == productId)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }

        public async Task UpdateAsync(TransactionModel transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TransactionModel>> GetRecentAsync(int businessId, int count = 10)
        {
            return await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId)
                .OrderByDescending(t => t.TransactionDate)
                .Take(count)
                .ToListAsync();
        }
    }
}
