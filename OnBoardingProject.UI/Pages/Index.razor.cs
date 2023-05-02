using Microsoft.AspNetCore.Components;
using OnBoardingProject.Common.Enums;
using OnBoardingProject.Common.Models;
using OnBoardingProject.UI.Services;
using Telerik.DataSource.Extensions;

namespace OnBoardingProject.UI.Pages
{
    public partial class Index : ComponentBase
    {
        private IEnumerable<ProductModel> products = new List<ProductModel>();
        private IEnumerable<ProductModel> filteredProducts = new List<ProductModel>();

        [Inject]
        ProductsService ProductsService { get; set; }

        [Inject]
        StateManager StateManager { get; set; }

        private bool isModalVisible = false;
        private bool canChangePage = true;
        private ProductModel selectedProduct = new();

        private readonly Dictionary<int, string> selectOptions = new();
        private int selectedCategory = -1;

        protected override async Task OnInitializedAsync()
        {
            selectOptions[-1] = "All";
            selectOptions.AddRange(Enum.GetValues<ProductCategory>()
                .Select(p => new KeyValuePair<int, string>((int)p, p.ToString())));

            products = await ProductsService.GetProductsAsync();
            FilterProducts();
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

        private void FilterChanged()
        {
            FilterProducts();
        }

        private void FilterProducts()
        {
            filteredProducts = products.Where(p => selectedCategory == -1 || (int)p.Category == selectedCategory);
        }
    }
}