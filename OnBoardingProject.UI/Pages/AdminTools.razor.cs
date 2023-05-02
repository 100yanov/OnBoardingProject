using Microsoft.AspNetCore.Components;
using OnBoardingProject.Common.Models;
using OnBoardingProject.UI.Services;
using System.Net.Http.Json;
namespace OnBoardingProject.UI.Pages
{
    public partial class AdminTools
    {
        public IEnumerable<ProductModel> Products { get; set; }

        private ProductModel product;
        private bool showConfirmDialog = false;

        [Inject]
        ProductsService ProductsService { get; set; }
      
        protected override async Task OnInitializedAsync()
        {
            Products = await ProductsService.GetProductsAsync();
        }     
        
        private async Task OnDelete(ProductModel product)
        {
            this.product = product;
            showConfirmDialog = true;
        }

        private async Task Delete()
        {            
            await ProductsService.DeleteProductAsync(product.Id);
            showConfirmDialog = false;
            Products = await ProductsService.GetProductsAsync();
            StateHasChanged();
        }
    }
}