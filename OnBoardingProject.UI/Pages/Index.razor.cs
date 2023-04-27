using Microsoft.AspNetCore.Components;
using OnBoardingProject.Common.Models;
using OnBoardingProject.UI.Services;
using System.Net.Http.Json;

namespace OnBoardingProject.UI.Pages
{
    public partial class Index : ComponentBase
    {
        public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();

        [Inject]
        HttpClient HttpClient { get; set; }

        [Inject]
        StateManager StateManager { get; set; }

        private bool isModalVisible = false;
        private bool canChangePage = true;
        private ProductModel selectedProduct = new();

        protected override async Task OnInitializedAsync()
        {
            Products = await HttpClient.GetFromJsonAsync<IEnumerable<ProductModel>>("Products");
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