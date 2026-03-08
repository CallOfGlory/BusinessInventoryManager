using WebApplication2.Models;

namespace WebApplication2.Interface
{
    public interface IProductRepository
    {
        Task AddProduct(ProductModel productModel);
        Task RemoveProduct(int productId);
        Task<List<ProductModel>> GetProducts(int userId);
        Task<List<ProductModel>> GetProductsByBusinessId(int businessId);
        Task<ProductModel?> GetProduct(int productId);
        Task UpdateProduct(ProductModel productModel);
        Task<List<ProductModel>> GetLowStockProducts(int businessId);
    }
}
