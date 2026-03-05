using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Interface;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _aplicationContext;
        public ProductRepository(ApplicationContext applicationContext)
        {
            _aplicationContext = applicationContext;
        }
        public async Task AddProduct(ProductModel productModel)
        {
            try
            {
                await _aplicationContext.Products.AddAsync(productModel);
                await _aplicationContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding product: {ex.Message}");
            }

        }

        public Task<ProductModel> GetProduct(int productId)
        {
            try
            {
                return _aplicationContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
            }
            catch
            {
                throw new Exception("Error retrieving product.");
            }
        }

        public async Task<List<ProductModel>> GetProducts(int userId)
        {
            try
            {
                return await _aplicationContext.Products
                    .Where(p => p.UserId == userId)
                    .ToListAsync();
            }
            catch
            {
                throw new Exception("Error retrieving products for user.");
            }
        }

        public async Task RemoveProduct(int productId)
        {
            try
            {
                var product = await _aplicationContext.Products.FindAsync(productId);
                if (product != null)
                {
                    _aplicationContext.Products.Remove(product);
                    await _aplicationContext.SaveChangesAsync();
                }
            }
            catch
            {
                throw new Exception("Error removing product.");
            }
        }
        public async Task UpdateProduct(ProductModel updatedProduct)
        {
            try
            {
                ProductModel existingProduct = _aplicationContext.Products.FirstOrDefault(p => p.Id == updatedProduct.Id);
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Category = updatedProduct.Category;
                await _aplicationContext.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Error updating product.");
            }
        }
    }
}
