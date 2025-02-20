using System.Net.Http.Json;
using InventoryHub.Client.Models;

namespace InventoryHub.Client.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                var products = await _httpClient.GetFromJsonAsync<List<Product>>("api/productlist");
                return products ?? new List<Product>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching products: {ex.Message}");
                return new List<Product>();
            }
        }
    }
}
