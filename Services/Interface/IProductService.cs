using WebApplication2.Models;

namespace WebApplication2.Services.Interface
{
    public interface IProductService
    {
        Task<ProductModel> CreateProductAsync(ProductModel product);
        Task<ProductModel> UpdateProductAsync(ProductModel product);
        Task<bool> DeleteProductAsync(int productId, int userId);
        Task<List<ProductModel>> GetUserProductsAsync(int userId);
        Task<List<ProductModel>> GetBusinessProductsAsync(int businessId);
        Task<ProductModel?> GetProductByIdAsync(int productId, int userId);
        Task<List<ProductModel>> GetLowStockProductsAsync(int businessId, int threshold = 10);
        Task<List<ProductModel>> SearchProductsAsync(int businessId, string searchTerm);
    }
}
