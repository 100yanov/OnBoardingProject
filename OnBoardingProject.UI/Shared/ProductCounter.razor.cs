using Microsoft.AspNetCore.Components;
using OnBoardingProject.UI.Services;

namespace OnBoardingProject.UI.Shared
{
    public partial class ProductCounter : ComponentBase , IDisposable
    {
        private int Counter { get; set; }

        [Inject] StateManager StateManager { get; set; }       

        protected override void OnInitialized()
        {
            this.StateManager.ReviewedProductsChanged += UpdateCounter;
            base.OnInitialized();
        }

        private void UpdateCounter(object? sender, int e)
        {
            Counter = e;
            StateHasChanged();
        }

        public void Dispose()
        {
            StateManager.ReviewedProductsChanged -= UpdateCounter;
        }
    }
}