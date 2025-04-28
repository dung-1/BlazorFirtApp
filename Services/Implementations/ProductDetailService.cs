using BlazorApp1.Data.Models;
using BlazorApp1.Data.Repository.Interfaces;
using BlazorApp1.Services.Interfaces;

namespace BlazorApp1.Services.Implementations
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IProductDetailRepository _productDetailRepository;

        public ProductDetailService(IProductDetailRepository productDetailRepository)
        {
            _productDetailRepository = productDetailRepository;
        }

        public async Task<IEnumerable<ProductDetail>> GetAllProductDetailsAsync()
        {
            return await _productDetailRepository.GetAllProductDetailsAsync();
        }

        public async Task<IEnumerable<ProductDetail>> GetProductDetailsByProductIdAsync(int productId)
        {
            return await _productDetailRepository.GetProductDetailsByProductIdAsync(productId);
        }

        public async Task<ProductDetail> GetProductDetailByIdAsync(int id)
        {
            return await _productDetailRepository.GetProductDetailByIdAsync(id);
        }

        public async Task<ProductDetail> CreateProductDetailAsync(ProductDetail productDetail)
        {
            return await _productDetailRepository.CreateProductDetailAsync(productDetail);
        }

        public async Task UpdateProductDetailAsync(ProductDetail productDetail)
        {
            await _productDetailRepository.UpdateProductDetailAsync(productDetail);
        }

        public async Task DeleteProductDetailAsync(int id)
        {
            await _productDetailRepository.DeleteProductDetailAsync(id);
        }

        public async Task<bool> ProductDetailExistsAsync(int id)
        {
            return await _productDetailRepository.ProductDetailExistsAsync(id);
        }
    }
}