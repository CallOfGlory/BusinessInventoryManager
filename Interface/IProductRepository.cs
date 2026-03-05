using WebApplication2.Models;

namespace WebApplication2.Interface
{
    public interface IProductRepository
    {
        public Task AddProduct(ProductModel productModel);
        public Task RemoveProduct(int productId);
        public Task<List<ProductModel>> GetProducts(int userId);
        public Task<ProductModel> GetProduct(int productId);
        public Task UpdateProduct(ProductModel productModel);
    }
}
