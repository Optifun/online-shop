using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using OnlineShop.Client;
using OnlineShop.Client.Services;
using OnlineShop.Client.Services.State;
using System;
using System.Net.Http;

Uri GetUri(WebAssemblyHostBuilder webAssemblyHostBuilder)
{
    Uri uri = new(webAssemblyHostBuilder.HostEnvironment.BaseAddress);
    if (!webAssemblyHostBuilder.HostEnvironment.IsDevelopment())
        return uri;

    string backend =
        uri.Scheme + "://" +
        uri.DnsSafeHost + ":7173/";
    return new Uri(backend);
}

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = true;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 6000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

builder.Services.AddScoped(sp => new HttpClient {BaseAddress = GetUri(builder)});

builder.Services.AddSingleton(sp => new HttpClient {BaseAddress = GetUri(builder)});
builder.Services.AddSingleton<AppState>();
builder.Services.AddSingleton<Navigation>();
builder.Services.AddTransient<CookieStorage>();

Console.WriteLine(GetUri(builder));

await builder.Build().RunAsync();