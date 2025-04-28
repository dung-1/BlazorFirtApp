using BlazorApp1.Data.DbContext;
using BlazorApp1.Data.Models;
using BlazorApp1.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data.Repository.Implementations
{
    public class ProductDetailRepository : IProductDetailRepository
    {
        private readonly AppDbContext _context;

        public ProductDetailRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDetail>> GetAllProductDetailsAsync()
        {
            return await _context.ProductDetails
                .Include(pd => pd.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductDetail>> GetProductDetailsByProductIdAsync(int productId)
        {
            return await _context.ProductDetails
                .Where(pd => pd.ProductId == productId)
                .ToListAsync();
        }

        public async Task<ProductDetail> GetProductDetailByIdAsync(int id)
        {
            return await _context.ProductDetails
                .Include(pd => pd.Product)
                .FirstOrDefaultAsync(pd => pd.Id == id);
        }

        public async Task<ProductDetail> CreateProductDetailAsync(ProductDetail productDetail)
        {
            _context.ProductDetails.Add(productDetail);
            await _context.SaveChangesAsync();
            return productDetail;
        }

        public async Task UpdateProductDetailAsync(ProductDetail productDetail)
        {
            _context.Entry(productDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductDetailAsync(int id)
        {
            var productDetail = await _context.ProductDetails.FindAsync(id);
            if (productDetail != null)
            {
                _context.ProductDetails.Remove(productDetail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ProductDetailExistsAsync(int id)
        {
            return await _context.ProductDetails.AnyAsync(pd => pd.Id == id);
        }
    }
}
