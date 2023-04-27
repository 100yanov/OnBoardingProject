using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OnBoardingProject.UI;
using OnBoardingProject.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<HttpClient>(_ => new HttpClient { BaseAddress = new Uri("https://localhost:7191/api/") }); //TODO: move to settings
builder.Services.AddScoped<ProductsService>();
builder.Services.AddSingleton<StateManager>();
builder.Services.AddTelerikBlazor();

var app = builder.Build();

await builder.Build().RunAsync();
