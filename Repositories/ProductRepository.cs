using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Interface;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ProductModel?> GetById(int productId)
        {
            return await _context.Products
                .Include(p => p.Business)
                .FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<List<ProductModel>> GetByUserId(int userId)
        {
            return await _context.Products
                .Where(p => p.UserId == userId && p.IsActive)
                .OrderByDescending(p => p.UpdatedAt)
                .ToListAsync();
        }

        public async Task<List<ProductModel>> GetByBusinessId(int businessId)
        {
            return await _context.Products
                .Where(p => p.BusinessId == businessId && p.IsActive)
                .OrderByDescending(p => p.UpdatedAt)
                .ToListAsync();
        }

        public async Task<ProductModel> Add(ProductModel product)
        {
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<ProductModel> Update(ProductModel product)
        {
            var existing = await _context.Products.FindAsync(product.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            existing.Name = product.Name;
            existing.SKU = product.SKU;
            existing.PurchasePrice = product.PurchasePrice;
            existing.SalePrice = product.SalePrice;
            existing.Quantity = product.Quantity;
            existing.MinStockLevel = product.MinStockLevel;
            existing.Description = product.Description;
            existing.Category = product.Category;
            existing.ImageUrl = product.ImageUrl;
            existing.IsActive = product.IsActive;
            existing.BusinessId = product.BusinessId;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) return false;

            // Soft delete - just mark as inactive
            product.IsActive = false;
            product.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProductModel>> GetLowStockProducts(int businessId, int threshold = 10)
        {
            return await _context.Products
                .Where(p => p.BusinessId == businessId && 
                           p.IsActive && 
                           p.Quantity <= (p.MinStockLevel ?? threshold))
                .OrderBy(p => p.Quantity)
                .ToListAsync();
        }

        public async Task<List<ProductModel>> SearchProducts(int businessId, string searchTerm)
        {
            var term = searchTerm.ToLower();
            return await _context.Products
                .Where(p => p.BusinessId == businessId && 
                           p.IsActive &&
                           (p.Name.ToLower().Contains(term) || 
                            (p.SKU != null && p.SKU.ToLower().Contains(term)) ||
                            (p.Category != null && p.Category.ToLower().Contains(term))))
                .OrderByDescending(p => p.UpdatedAt)
                .ToListAsync();
        }
    }
}
