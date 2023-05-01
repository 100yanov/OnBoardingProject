using Microsoft.AspNetCore.Components;
using OnBoardingProject.Common.Models;
using OnBoardingProject.UI.Services;

namespace OnBoardingProject.UI.Pages
{
    public partial class Index : ComponentBase
    {
        public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();

        [Inject]
        ProductsService ProductsService { get; set; }

        [Inject]
        StateManager StateManager { get; set; }

        private bool isModalVisible = false;
        private bool canChangePage = true;
        private ProductModel selectedProduct = new();

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductsService.GetProductsAsync();
        }

        private void ShowModal(ProductModel product)
        {
            this.selectedProduct = product;
            ModalShowChanged(true);
        }

        private void OnShowModal(ProductModel product)
        {
            ShowModal(product);
            StateManager.IncrementProductsReviewedCount();
        }

        private void ModalShowChanged(bool currVisible)
        {
            isModalVisible = currVisible;
            canChangePage = !currVisible;
        }
    }
}