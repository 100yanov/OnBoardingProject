using OnBoardingProject.Common.Models;
using System.Net.Http.Json;

namespace OnBoardingProject.UI.Services
{
    public class ProductsService
    {
        private readonly HttpClient httpClient;
        public ProductsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<ProductModel>>("Products");
        }

        public async Task AddProductAsync(ProductModel product)
        {
            await httpClient.PostAsJsonAsync("Products", product);
        }
    }
}
