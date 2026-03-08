using WebApplication2.Models;

namespace WebApplication2.Interface
{
    public interface ITransactionRepository
    {
        Task<TransactionModel> AddAsync(TransactionModel transaction);
        Task<TransactionModel?> GetByIdAsync(int id);
        Task<List<TransactionModel>> GetByBusinessIdAsync(int businessId, DateTime? startDate = null, DateTime? endDate = null);
        Task<List<TransactionModel>> GetByProductIdAsync(int productId);
        Task UpdateAsync(TransactionModel transaction);
        Task DeleteAsync(int id);
        Task<List<TransactionModel>> GetRecentAsync(int businessId, int count = 10);
    }
}
