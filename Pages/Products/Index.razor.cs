<<<<<<< HEAD
﻿using BlazorApp1.Services.Interfaces;
=======
﻿using BlazorApp1.Data.Models;
using BlazorApp1.Data.Repository.Interfaces;
using BlazorApp1.Services.Interfaces;
>>>>>>> 7e2fb0bff8c1c90ba9839e522a766f0fd0b2bd04
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp1.Pages.Products
{
    public class ProductBase : ComponentBase
    {
        [Inject] private IProductService ProductService { get; set; }
        [Inject] private IJSRuntime JSRuntime { get; set; }

        protected IEnumerable<Product> products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadProducts();
        }

        protected async Task LoadProducts()
        {
            try
            {
<<<<<<< HEAD
                products = (IEnumerable<Product>)await ProductService.GetAllProductsAsync();
=======
                products = await ProductService.GetAllProductsAsync();
>>>>>>> 7e2fb0bff8c1c90ba9839e522a766f0fd0b2bd04
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading products: {ex.Message}");
            }
        }

        protected async Task DeleteProduct(int id)
        {
            try
            {
                bool confirm = await JSRuntime.InvokeAsync<bool>("confirm", "Bạn có chắc chắn muốn xóa sản phẩm này?");
                if (confirm)
                {
                    await ProductService.DeleteProductAsync(id);
                    await LoadProducts();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product: {ex.Message}");
            }
        }
    }
}
