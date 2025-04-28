using BlazorApp1.Data.Models;
using BlazorApp1.Data.Repository.Interfaces;
using BlazorApp1.Services.Interfaces;

namespace BlazorApp1.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<Product> GetProductWithDetailsAsync(int id)
        {
            return await _productRepository.GetProductWithDetailsAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            return await _productRepository.CreateProductAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }

        public async Task<bool> ProductExistsAsync(int id)
        {
            return await _productRepository.ProductExistsAsync(id);
        }
    }
}
