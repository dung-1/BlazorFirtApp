using BlazorApp1.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace BlazorApp1.Data.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductDetails)
                .WithOne(pd => pd.Product)
                .HasForeignKey(pd => pd.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed some initial data
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Laptop Dell XPS 13",
                    Price = 1299.99m,
                    Description = "Laptop cao cấp với hiệu năng mạnh mẽ",
                    CreatedDate = System.DateTime.Now,
                    IsAvailable = true
                },
                new Product
                {
                    Id = 2,
                    Name = "iPhone 14 Pro",
                    Price = 999.99m,
                    Description = "Điện thoại thông minh mới nhất từ Apple",
                    CreatedDate = System.DateTime.Now,
                    IsAvailable = true
                }
            );
            modelBuilder.Entity<ProductDetail>().HasData(
               new ProductDetail
               {
                   Id = 1,
                   ProductId = 1,
                   SKU = "DELL-XPS-13-SILVER",
                   Color = "Silver",
                   Size = "13 inch",
                   Stock = 10,
                   ImageUrl = "/images/dell-xps-13-silver.jpg"
               },
               new ProductDetail
               {
                   Id = 2,
                   ProductId = 1,
                   SKU = "DELL-XPS-13-BLACK",
                   Color = "Black",
                   Size = "13 inch",
                   Stock = 15,
                   ImageUrl = "/images/dell-xps-13-black.jpg"
               },
               new ProductDetail
               {
                   Id = 3,
                   ProductId = 2,
                   SKU = "IPHONE-14-PRO-BLACK",
                   Color = "Black",
                   Size = "6.1 inch",
                   Stock = 20,
                   ImageUrl = "/images/iphone-14-pro-black.jpg"
               }
           );
        }
    }
}
