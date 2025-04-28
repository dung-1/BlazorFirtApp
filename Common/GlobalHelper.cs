using BlazorApp1.Data.Repository.Implementations;
using BlazorApp1.Data.Repository.Interfaces;
using BlazorApp1.Services.Implementations;
using BlazorApp1.Services.Interfaces;

namespace BlazorApp1.Common
{
    public static class GlobalHelper
    {
        /// <summary>
        /// Phương thức mở rộng để đăng ký các dịch vụ (Services) vào Dependency Injection container.
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <returns>IServiceCollection</returns>

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // Đăng ký AutoMapper
            //services.AddAutoMapper(typeof(Program));

            // Đăng ký Repository
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductDetailRepository, ProductDetailRepository>();

            // Đăng ký các dịch vụ của bạn ở đây
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();
            return services;
        }
    }
}
