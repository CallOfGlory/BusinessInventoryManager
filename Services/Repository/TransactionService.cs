using WebApplication2.Interface;
using WebApplication2.Models;
using WebApplication2.Services.Interface;
using WebApplication2.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Services.Repository
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ApplicationContext _context;

        public TransactionService(ITransactionRepository transactionRepository, ApplicationContext context)
        {
            _transactionRepository = transactionRepository;
            _context = context;
        }

        public async Task<TransactionModel> CreateTransactionAsync(TransactionModel transaction, int businessId)
        {
            transaction.BusinessId = businessId;
            transaction.CreatedAt = DateTime.UtcNow;
            transaction.TotalAmount = transaction.Quantity * transaction.UnitPrice;

            // Update product stock based on transaction type
            var product = await _context.Products.FindAsync(transaction.ProductId);
            if (product != null)
            {
                switch (transaction.Type)
                {
                    case TransactionType.Purchase:
                        product.Quantity += transaction.Quantity;
                        break;
                    case TransactionType.Sale:
                        if (product.Quantity < transaction.Quantity)
                            throw new InvalidOperationException("Insufficient stock");
                        product.Quantity -= transaction.Quantity;
                        break;
                    case TransactionType.Return:
                        product.Quantity += transaction.Quantity;
                        break;
                    case TransactionType.WriteOff:
                        product.Quantity -= transaction.Quantity;
                        break;
                    case TransactionType.Adjustment:
                        // Adjustment can be positive or negative
                        product.Quantity = transaction.Quantity;
                        break;
                }
                product.UpdatedAt = DateTime.UtcNow;
            }

            var created = await _transactionRepository.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return created;
        }

        public async Task<TransactionModel?> GetTransactionByIdAsync(int id, int businessId)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            if (transaction == null || transaction.BusinessId != businessId)
                return null;
            return transaction;
        }

        public async Task<List<TransactionModel>> GetTransactionsAsync(int businessId, DateTime? startDate = null, DateTime? endDate = null, TransactionType? type = null)
        {
            var transactions = await _transactionRepository.GetByBusinessIdAsync(businessId, startDate, endDate);

            if (type.HasValue)
                transactions = transactions.Where(t => t.Type == type.Value).ToList();

            return transactions;
        }

        public async Task<List<TransactionModel>> GetRecentTransactionsAsync(int businessId, int count = 10)
        {
            return await _transactionRepository.GetRecentAsync(businessId, count);
        }

        public async Task UpdateTransactionAsync(TransactionModel transaction, int businessId)
        {
            var existing = await _transactionRepository.GetByIdAsync(transaction.Id);
            if (existing == null || existing.BusinessId != businessId)
                throw new UnauthorizedAccessException("Transaction not found or access denied");

            // Reverse the old stock change
            var product = await _context.Products.FindAsync(existing.ProductId);
            if (product != null)
            {
                switch (existing.Type)
                {
                    case TransactionType.Purchase:
                        product.Quantity -= existing.Quantity;
                        break;
                    case TransactionType.Sale:
                        product.Quantity += existing.Quantity;
                        break;
                    case TransactionType.Return:
                        product.Quantity -= existing.Quantity;
                        break;
                    case TransactionType.WriteOff:
                        product.Quantity += existing.Quantity;
                        break;
                }
            }

            // Apply new values
            existing.ProductId = transaction.ProductId;
            existing.Type = transaction.Type;
            existing.Quantity = transaction.Quantity;
            existing.UnitPrice = transaction.UnitPrice;
            existing.TotalAmount = transaction.Quantity * transaction.UnitPrice;
            existing.Notes = transaction.Notes;
            existing.TransactionDate = transaction.TransactionDate;

            // Apply new stock change
            var newProduct = await _context.Products.FindAsync(transaction.ProductId);
            if (newProduct != null)
            {
                switch (transaction.Type)
                {
                    case TransactionType.Purchase:
                        newProduct.Quantity += transaction.Quantity;
                        break;
                    case TransactionType.Sale:
                        newProduct.Quantity -= transaction.Quantity;
                        break;
                    case TransactionType.Return:
                        newProduct.Quantity += transaction.Quantity;
                        break;
                    case TransactionType.WriteOff:
                        newProduct.Quantity -= transaction.Quantity;
                        break;
                }
                newProduct.UpdatedAt = DateTime.UtcNow;
            }

            await _transactionRepository.UpdateAsync(existing);
        }

        public async Task DeleteTransactionAsync(int id, int businessId)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            if (transaction == null || transaction.BusinessId != businessId)
                throw new UnauthorizedAccessException("Transaction not found or access denied");

            // Reverse the stock change
            var product = await _context.Products.FindAsync(transaction.ProductId);
            if (product != null)
            {
                switch (transaction.Type)
                {
                    case TransactionType.Purchase:
                        product.Quantity -= transaction.Quantity;
                        break;
                    case TransactionType.Sale:
                        product.Quantity += transaction.Quantity;
                        break;
                    case TransactionType.Return:
                        product.Quantity -= transaction.Quantity;
                        break;
                    case TransactionType.WriteOff:
                        product.Quantity += transaction.Quantity;
                        break;
                }
                product.UpdatedAt = DateTime.UtcNow;
            }

            await _transactionRepository.DeleteAsync(id);
            await _context.SaveChangesAsync();
        }

        public async Task<(double totalSales, double totalPurchases, double netProfit)> GetTransactionSummaryAsync(int businessId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var transactions = await GetTransactionsAsync(businessId, startDate, endDate);

            var totalSales = transactions
                .Where(t => t.Type == TransactionType.Sale)
                .Sum(t => t.TotalAmount);

            var totalPurchases = transactions
                .Where(t => t.Type == TransactionType.Purchase)
                .Sum(t => t.TotalAmount);

            var totalReturns = transactions
                .Where(t => t.Type == TransactionType.Return)
                .Sum(t => t.TotalAmount);

            // Calculate profit considering cost of goods sold
            var netProfit = totalSales - totalReturns;

            return (totalSales, totalPurchases, netProfit - totalPurchases);
        }
    }
}
