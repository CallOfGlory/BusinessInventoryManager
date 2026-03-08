using WebApplication2.Interface;
using WebApplication2.Models;
using WebApplication2.Services.Interface;

namespace WebApplication2.Services.Repository
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IProductRepository _productRepository;

        public TransactionService(ITransactionRepository transactionRepository, IProductRepository productRepository)
        {
            _transactionRepository = transactionRepository;
            _productRepository = productRepository;
        }

        public async Task<TransactionModel?> GetTransactionByIdAsync(int id, int businessId)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            if (transaction == null || transaction.BusinessId != businessId)
            {
                return null;
            }
            return transaction;
        }

        public async Task<IEnumerable<TransactionModel>> GetBusinessTransactionsAsync(int businessId)
        {
            return await _transactionRepository.GetByBusinessIdAsync(businessId);
        }

        public async Task<IEnumerable<TransactionModel>> GetTransactionsByDateRangeAsync(int businessId, DateTime startDate, DateTime endDate)
        {
            return await _transactionRepository.GetByDateRangeAsync(businessId, startDate, endDate);
        }

        public async Task<IEnumerable<TransactionModel>> GetRecentTransactionsAsync(int businessId, int count = 10)
        {
            return await _transactionRepository.GetRecentTransactionsAsync(businessId, count);
        }

        public async Task<TransactionModel> RecordPurchaseAsync(int businessId, int productId, int quantity, double unitPrice, string? notes = null)
        {
            // Update product quantity (increase)
            var product = await _productRepository.GetById(productId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            product.Quantity += quantity;
            product.UpdatedAt = DateTime.UtcNow;
            await _productRepository.Update(product);

            // Create transaction record
            var transaction = new TransactionModel
            {
                BusinessId = businessId,
                ProductId = productId,
                Type = TransactionType.Purchase,
                Quantity = quantity,
                UnitPrice = unitPrice,
                TotalAmount = quantity * unitPrice,
                Notes = notes,
                TransactionDate = DateTime.UtcNow
            };

            return await _transactionRepository.AddAsync(transaction);
        }

        public async Task<TransactionModel> RecordSaleAsync(int businessId, int productId, int quantity, double unitPrice, string? notes = null)
        {
            // Update product quantity (decrease)
            var product = await _productRepository.GetById(productId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            if (product.Quantity < quantity)
            {
                throw new Exception($"Insufficient stock. Available: {product.Quantity}, Requested: {quantity}");
            }

            product.Quantity -= quantity;
            product.UpdatedAt = DateTime.UtcNow;
            await _productRepository.Update(product);

            // Create transaction record
            var transaction = new TransactionModel
            {
                BusinessId = businessId,
                ProductId = productId,
                Type = TransactionType.Sale,
                Quantity = quantity,
                UnitPrice = unitPrice,
                TotalAmount = quantity * unitPrice,
                Notes = notes,
                TransactionDate = DateTime.UtcNow
            };

            return await _transactionRepository.AddAsync(transaction);
        }

        public async Task<TransactionModel> RecordAdjustmentAsync(int businessId, int productId, int quantity, string? notes = null)
        {
            // Update product quantity (can be positive or negative)
            var product = await _productRepository.GetById(productId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            product.Quantity += quantity;
            if (product.Quantity < 0)
            {
                product.Quantity = 0;
            }
            product.UpdatedAt = DateTime.UtcNow;
            await _productRepository.Update(product);

            // Create transaction record
            var transaction = new TransactionModel
            {
                BusinessId = businessId,
                ProductId = productId,
                Type = TransactionType.Adjustment,
                Quantity = quantity,
                UnitPrice = product.PurchasePrice,
                TotalAmount = Math.Abs(quantity) * product.PurchasePrice,
                Notes = notes,
                TransactionDate = DateTime.UtcNow
            };

            return await _transactionRepository.AddAsync(transaction);
        }

        public async Task<bool> DeleteTransactionAsync(int id, int businessId)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            if (transaction == null || transaction.BusinessId != businessId)
            {
                return false;
            }

            // Note: We don't reverse the stock changes when deleting a transaction
            // This should be handled separately if needed
            return await _transactionRepository.DeleteAsync(id);
        }
    }
}
