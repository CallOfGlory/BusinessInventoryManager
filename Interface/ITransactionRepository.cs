using WebApplication2.Models;

namespace WebApplication2.Interface
{
    public interface ITransactionRepository
    {
        Task<TransactionModel?> GetByIdAsync(int id);
        Task<IEnumerable<TransactionModel>> GetByBusinessIdAsync(int businessId);
        Task<IEnumerable<TransactionModel>> GetByProductIdAsync(int productId);
        Task<IEnumerable<TransactionModel>> GetByDateRangeAsync(int businessId, DateTime startDate, DateTime endDate);
        Task<IEnumerable<TransactionModel>> GetRecentTransactionsAsync(int businessId, int count = 10);
        Task<TransactionModel> AddAsync(TransactionModel transaction);
        Task<bool> DeleteAsync(int id);
    }
}
