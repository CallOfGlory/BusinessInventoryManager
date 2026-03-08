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

        public async Task<ProductModel> CreateProductAsync(ProductModel productModel, int businessId)
        {
            productModel.BusinessId = businessId;
            productModel.CreatedAt = DateTime.UtcNow;
            productModel.IsActive = true;

            // Generate SKU if not provided
            if (string.IsNullOrEmpty(productModel.SKU))
            {
                productModel.SKU = GenerateSKU(productModel.Name);
            }

            await _productRepository.AddProduct(productModel);
            _logger.LogInformation($"Product {productModel.Name} created for business {businessId}");
            return productModel;
        }

        public async Task DeleteProductAsync(int productId, int businessId)
        {
            var product = await _productRepository.GetProduct(productId);
            if (product == null || product.BusinessId != businessId)
            {
                throw new UnauthorizedAccessException("Product not found or access denied.");
            }
            await _productRepository.RemoveProduct(productId);
            _logger.LogInformation($"Product {productId} deleted from business {businessId}");
        }

        public async Task<ProductModel?> GetProductByIdAsync(int productId, int businessId)
        {
            var product = await _productRepository.GetProduct(productId);
            if (product == null || product.BusinessId != businessId)
            {
                return null;
            }
            return product;
        }

        public async Task<List<ProductModel>> GetBusinessProductsAsync(int businessId)
        {
            return await _productRepository.GetProductsByBusinessId(businessId);
        }

        public async Task<List<ProductModel>> GetLowStockProductsAsync(int businessId)
        {
            return await _productRepository.GetLowStockProducts(businessId);
        }

        public async Task UpdateProductAsync(ProductModel productModel, int businessId)
        {
            var existingProduct = await _productRepository.GetProduct(productModel.Id);

            if (existingProduct == null)
                throw new KeyNotFoundException("Product not found");

            if (existingProduct.BusinessId != businessId)
                throw new UnauthorizedAccessException("Access denied");

            existingProduct.Name = productModel.Name;
            existingProduct.SKU = productModel.SKU;
            existingProduct.PurchasePrice = productModel.PurchasePrice;
            existingProduct.SalePrice = productModel.SalePrice;
            existingProduct.Quantity = productModel.Quantity;
            existingProduct.MinStockLevel = productModel.MinStockLevel;
            existingProduct.Description = productModel.Description;
            existingProduct.Category = productModel.Category;
            existingProduct.SupplierId = productModel.SupplierId;
            existingProduct.UpdatedAt = DateTime.UtcNow;

            await _productRepository.UpdateProduct(existingProduct);
            _logger.LogInformation($"Product {productModel.Id} updated");
        }

        private string GenerateSKU(string productName)
        {
            var prefix = new string(productName.ToUpper()
                .Where(char.IsLetter)
                .Take(3)
                .ToArray());
            var timestamp = DateTime.UtcNow.ToString("yyMMddHHmm");
            return $"{prefix}-{timestamp}";
        }
    }
}
