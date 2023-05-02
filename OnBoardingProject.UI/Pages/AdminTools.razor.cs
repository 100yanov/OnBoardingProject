using Microsoft.AspNetCore.Components;
using OnBoardingProject.Common.Models;
using OnBoardingProject.UI.Services;
using System.Net.Http.Json;
namespace OnBoardingProject.UI.Pages
{
    public partial class AdminTools
    {
        public IEnumerable<ProductModel> Products { get; set; }


        [Inject]
        ProductsService ProductsService { get; set; }
      
        protected override async Task OnInitializedAsync()
        {
            Products = await ProductsService.GetProductsAsync();
        }     
        
        private async Task OnDelete(Guid id)
        {
            await ProductsService.DeleteProductAsync(id);//todo: add confirm modal
            StateHasChanged();
        }
    }
}