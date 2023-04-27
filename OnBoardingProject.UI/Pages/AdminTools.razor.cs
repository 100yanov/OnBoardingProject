using Microsoft.AspNetCore.Components;
using OnBoardingProject.Common.Models;

using System.Net.Http.Json;

namespace OnBoardingProject.UI.Pages
{
    public partial class AdminTools
    {
        public IEnumerable<ProductModel> Products { get; set; } 


        [Inject]
        HttpClient HttpClient { get; set; }    //todo: add service     

        protected override async Task OnInitializedAsync()
        {
            Products = await HttpClient.GetFromJsonAsync<IEnumerable<ProductModel>>("Products");
        }

    }
}