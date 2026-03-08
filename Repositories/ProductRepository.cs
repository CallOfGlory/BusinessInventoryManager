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

        public async Task AddProduct(ProductModel productModel)
        {
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductModel?> GetProduct(int productId)
        {
            return await _context.Products
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<List<ProductModel>> GetProducts(int userId)
        {
            return await _context.Products
                .Include(p => p.Supplier)
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<ProductModel>> GetProductsByBusinessId(int businessId)
        {
            return await _context.Products
                .Include(p => p.Supplier)
                .Where(p => p.BusinessId == businessId && p.IsActive)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task RemoveProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                product.IsActive = false; // Soft delete
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateProduct(ProductModel updatedProduct)
        {
            var existingProduct = await _context.Products.FindAsync(updatedProduct.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.SKU = updatedProduct.SKU;
                existingProduct.PurchasePrice = updatedProduct.PurchasePrice;
                existingProduct.SalePrice = updatedProduct.SalePrice;
                existingProduct.Quantity = updatedProduct.Quantity;
                existingProduct.MinStockLevel = updatedProduct.MinStockLevel;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Category = updatedProduct.Category;
                existingProduct.SupplierId = updatedProduct.SupplierId;
                existingProduct.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ProductModel>> GetLowStockProducts(int businessId)
        {
            return await _context.Products
                .Where(p => p.BusinessId == businessId && p.IsActive && p.Quantity <= p.MinStockLevel)
                .OrderBy(p => p.Quantity)
                .ToListAsync();
        }
    }
}
