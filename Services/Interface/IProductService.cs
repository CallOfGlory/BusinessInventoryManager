using WebApplication2.Models;

namespace WebApplication2.Services.Interface
{
    public interface IProductService
    {
        Task<ProductModel> CreateProductAsync(ProductModel productModel);
        Task UpdateProductAsync(ProductModel productModel);
        Task DeleteProductAsync(int productId, int userId);
        Task<List<ProductModel>> GetUserProductsAsync(int userId);
        Task<ProductModel> GetProductByIdAsync(int productId, int userId);
    }
}
