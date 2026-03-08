using WebApplication2.Models;

namespace WebApplication2.Services.Interface
{
    public interface IProductService
    {
        Task<ProductModel> CreateProductAsync(ProductModel productModel, int businessId);
        Task UpdateProductAsync(ProductModel productModel, int businessId);
        Task DeleteProductAsync(int productId, int businessId);
        Task<List<ProductModel>> GetBusinessProductsAsync(int businessId);
        Task<ProductModel?> GetProductByIdAsync(int productId, int businessId);
        Task<List<ProductModel>> GetLowStockProductsAsync(int businessId);
    }
}
