using Microsoft.AspNetCore.Components;
using OnBoardingProject.Common.Models;
using OnBoardingProject.UI.Services;

namespace OnBoardingProject.UI.Pages
{
    public partial class AddToyForm : ComponentBase
    {
        public ProductModel Product { get; set; } = new();
        [Inject] ProductsService ProductsService { get; set; }

        private async Task OnSubmit()
        {
            await ProductsService.AddProductAsync(Product);
            StateHasChanged();
        }
    }
}