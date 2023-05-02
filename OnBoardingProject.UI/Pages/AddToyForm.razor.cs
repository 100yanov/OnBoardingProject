using Microsoft.AspNetCore.Components;
using OnBoardingProject.Common.Models;
using OnBoardingProject.UI.Services;

namespace OnBoardingProject.UI.Pages
{
    public partial class AddToyForm : ComponentBase
    {
        [Inject] ProductsService ProductsService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        public ProductModel Product { get; set; } = new();

        
        private async Task OnSubmit()
        {
            await ProductsService.AddProductAsync(Product);
            StateHasChanged();
            NavigationManager.NavigateTo("admin");
        }
    }
}