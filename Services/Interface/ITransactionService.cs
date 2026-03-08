using WebApplication2.Models;

namespace WebApplication2.Services.Interface
{
    public interface ITransactionService
    {
        Task<TransactionModel?> GetTransactionByIdAsync(int id, int businessId);
        Task<IEnumerable<TransactionModel>> GetBusinessTransactionsAsync(int businessId);
        Task<IEnumerable<TransactionModel>> GetTransactionsByDateRangeAsync(int businessId, DateTime startDate, DateTime endDate);
        Task<IEnumerable<TransactionModel>> GetRecentTransactionsAsync(int businessId, int count = 10);
        Task<TransactionModel> RecordPurchaseAsync(int businessId, int productId, int quantity, double unitPrice, string? notes = null);
        Task<TransactionModel> RecordSaleAsync(int businessId, int productId, int quantity, double unitPrice, string? notes = null);
        Task<TransactionModel> RecordAdjustmentAsync(int businessId, int productId, int quantity, string? notes = null);
        Task<bool> DeleteTransactionAsync(int id, int businessId);
    }
}
