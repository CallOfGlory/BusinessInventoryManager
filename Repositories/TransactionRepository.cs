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

        public async Task<TransactionModel?> GetByIdAsync(int id)
        {
            return await _context.Transactions
                .Include(t => t.Product)
                .Include(t => t.Business)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TransactionModel>> GetByBusinessIdAsync(int businessId)
        {
            return await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TransactionModel>> GetByProductIdAsync(int productId)
        {
            return await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.ProductId == productId)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TransactionModel>> GetByDateRangeAsync(int businessId, DateTime startDate, DateTime endDate)
        {
            return await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId && 
                           t.TransactionDate >= startDate && 
                           t.TransactionDate <= endDate)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TransactionModel>> GetRecentTransactionsAsync(int businessId, int count = 10)
        {
            return await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId)
                .OrderByDescending(t => t.TransactionDate)
                .Take(count)
                .ToListAsync();
        }

        public async Task<TransactionModel> AddAsync(TransactionModel transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null) return false;

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
