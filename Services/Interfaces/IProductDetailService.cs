using BlazorApp1.Data.Models;

namespace BlazorApp1.Services.Interfaces
{
    public interface IProductDetailService
    {
        Task<IEnumerable<ProductDetail>> GetAllProductDetailsAsync();
        Task<IEnumerable<ProductDetail>> GetProductDetailsByProductIdAsync(int productId);
        Task<ProductDetail> GetProductDetailByIdAsync(int id);
        Task<ProductDetail> CreateProductDetailAsync(ProductDetail productDetail);
        Task UpdateProductDetailAsync(ProductDetail productDetail);
        Task DeleteProductDetailAsync(int id);
        Task<bool> ProductDetailExistsAsync(int id);
    }
}
