using BlazorApp1.Data.Models;

namespace BlazorApp1.Data
{
    public class ProductsService
    {
        private List<Productse> _products;
        public ProductsService()
        {
            _products = new List<Productse>
        {
            new Productse { Id = 1, Name = "Laptop Dell XPS 13", Price = 1299.99m, Category = "Electronics", IsAvailable = true },
            new Productse { Id = 2, Name = "Smartphone iPhone 13", Price = 999.99m, Category = "Electronics", IsAvailable = false },
            new Productse { Id = 3, Name = "Coffee Machine", Price = 89.95m, Category = "Home Appliances", IsAvailable = true },
            new Productse { Id = 4, Name = "Running Shoes", Price = 129.50m, Category = "Sports", IsAvailable = true },
            new Productse { Id = 5, Name = "Novel Book", Price = 15.75m, Category = "Books", IsAvailable = true }
        };
        }
        public List<Productse> GetAllProducts() => _products;

        public Productse GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void AddProduct(Productse product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }

        public void UpdateProduct(Productse  product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index != -1)
                _products[index] = product;
        }

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
                _products.Remove(product);
        }
    }
}
