using WebApplication2.Models;

namespace WebApplication2.Services.Interface
{
    public interface ITransactionService
    {
        Task<TransactionModel> CreateTransactionAsync(TransactionModel transaction, int businessId);
        Task<TransactionModel?> GetTransactionByIdAsync(int id, int businessId);
        Task<List<TransactionModel>> GetTransactionsAsync(int businessId, DateTime? startDate = null, DateTime? endDate = null, TransactionType? type = null);
        Task<List<TransactionModel>> GetRecentTransactionsAsync(int businessId, int count = 10);
        Task UpdateTransactionAsync(TransactionModel transaction, int businessId);
        Task DeleteTransactionAsync(int id, int businessId);
        Task<(double totalSales, double totalPurchases, double netProfit)> GetTransactionSummaryAsync(int businessId, DateTime? startDate = null, DateTime? endDate = null);
    }
}
