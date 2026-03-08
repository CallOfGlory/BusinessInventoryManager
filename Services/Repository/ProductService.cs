using WebApplication2.Interface;
using WebApplication2.Models;
using WebApplication2.Services.Interface;

namespace WebApplication2.Services.Repository
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<ProductModel> CreateProductAsync(ProductModel product)
        {
            return await _productRepository.Add(product);
        }

        public async Task<ProductModel> UpdateProductAsync(ProductModel product)
        {
            var existing = await _productRepository.GetById(product.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            if (existing.UserId != product.UserId)
            {
                throw new UnauthorizedAccessException("Access denied");
            }

            return await _productRepository.Update(product);
        }

        public async Task<bool> DeleteProductAsync(int productId, int userId)
        {
            var product = await _productRepository.GetById(productId);
            if (product == null || product.UserId != userId)
            {
                return false;
            }
            return await _productRepository.Delete(productId);
        }

        public async Task<List<ProductModel>> GetUserProductsAsync(int userId)
        {
            return await _productRepository.GetByUserId(userId);
        }

        public async Task<List<ProductModel>> GetBusinessProductsAsync(int businessId)
        {
            return await _productRepository.GetByBusinessId(businessId);
        }

        public async Task<ProductModel?> GetProductByIdAsync(int productId, int userId)
        {
            var product = await _productRepository.GetById(productId);
            if (product == null || product.UserId != userId)
            {
                return null;
            }
            return product;
        }

        public async Task<List<ProductModel>> GetLowStockProductsAsync(int businessId, int threshold = 10)
        {
            return await _productRepository.GetLowStockProducts(businessId, threshold);
        }

        public async Task<List<ProductModel>> SearchProductsAsync(int businessId, string searchTerm)
        {
            return await _productRepository.SearchProducts(businessId, searchTerm);
        }
    }
}
