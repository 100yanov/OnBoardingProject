using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using OnBoardingProject.UI;
using OnBoardingProject.UI.Shared;
using Telerik.Blazor;
using Telerik.Blazor.Components;
using Telerik.FontIcons;
using Telerik.SvgIcons;
using Telerik.Blazor.Components.Common.Icon;
using OnBoardingProject.Common.Models;
using OnBoardingProject.UI.Services;

namespace OnBoardingProject.UI.Pages
{
    public partial class EditToyForm
    {
        [Parameter]
        public Guid Id { get; set; }
        [Inject] ProductsService ProductsService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        public ProductModel Product { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            this.Product = await ProductsService.GetProductAsync(Id);            
        }

        private async Task OnSubmit()
        {
            await ProductsService.EditProductAsync(Product);
            StateHasChanged();
            NavigationManager.NavigateTo("admin");
        }
    }
}