using WebApplication2.Interface;
using WebApplication2.Models;
using WebApplication2.Services.Interface;

namespace WebApplication2.Repositories
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
        public async Task<ProductModel> CreateProductAsync(ProductModel productModel)
        {
            await _productRepository.AddProduct(productModel);
            return productModel;
        }

        public async Task DeleteProductAsync(int productId, int userId)
        {
            try
            {
                ProductModel productModel = await _productRepository.GetProduct(productId);
                if (productModel == null || productModel.UserId != userId)
                {
                    throw new Exception("Product not found or access denied.");
                }
                await _productRepository.RemoveProduct(productId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting product: {ex.Message}");
            }
        }

        public async Task<ProductModel> GetProductByIdAsync(int productId, int userId)
        {
            try
            {
                ProductModel productModel = await _productRepository.GetProduct(productId);
                if (productModel == null || productModel.UserId != userId)
                {
                    throw new Exception("Product not found or access denied.");
                }
                return productModel;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving product: {ex.Message}");
            }
        }

        public async Task<List<ProductModel>> GetUserProductsAsync(int userId)
        {
            try
            {
                return await _productRepository.GetProducts(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving products: {ex.Message}");
            }
        }

        public async Task UpdateProductAsync(ProductModel productModel)
        {
            var existingProduct = await _productRepository.GetProduct(productModel.Id);

            if (existingProduct == null)
                throw new KeyNotFoundException("Product not found");

            if (existingProduct.UserId != productModel.UserId)
                throw new UnauthorizedAccessException("Access denied");

            // Валідація оновлених даних
            if (!string.IsNullOrWhiteSpace(productModel.Name))
                existingProduct.Name = productModel.Name;

            if (productModel.Price > 0)
                existingProduct.Price = productModel.Price;

            if (!string.IsNullOrWhiteSpace(productModel.Description))
                existingProduct.Description = productModel.Description;

            if (!string.IsNullOrWhiteSpace(productModel.Category))
                existingProduct.Category = productModel.Category;

            await _productRepository.UpdateProduct(existingProduct);
            _logger.LogInformation($"Product {productModel.Id} updated");

        }
    }
}