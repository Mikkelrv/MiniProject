using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ThriftShopApp;
using ThriftShopApp.Services;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// General HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Specific HttpClient for ImgurService
builder.Services.AddScoped<IImgurService>(sp =>
{
    var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7077/") };
    return new ImgurService(httpClient);
});

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ILoginService, LoginServiceImpl>();
builder.Services.AddScoped<IItemHandlersService, ItemHandlerService>();

await builder.Build().RunAsync();