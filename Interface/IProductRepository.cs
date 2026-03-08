using WebApplication2.Models;

namespace WebApplication2.Interface
{
    public interface IProductRepository
    {
        Task<ProductModel?> GetById(int productId);
        Task<List<ProductModel>> GetByUserId(int userId);
        Task<List<ProductModel>> GetByBusinessId(int businessId);
        Task<ProductModel> Add(ProductModel product);
        Task<ProductModel> Update(ProductModel product);
        Task<bool> Delete(int productId);
        Task<List<ProductModel>> GetLowStockProducts(int businessId, int threshold = 10);
        Task<List<ProductModel>> SearchProducts(int businessId, string searchTerm);
    }
}
