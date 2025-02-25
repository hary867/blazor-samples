using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration.Memory;
using BlazorSample;
using static BlazorSample.Pages.ProductDetails;
using static BlazorSample.Pages.TheSunmakers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<NotifierService>();
builder.Services.AddSingleton<TimerService>();
builder.Services.AddSingleton<IDataAccess, DataAccess>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

var vehicleData = new Dictionary<string, string?>()
{
    { "color", "blue" },
    { "type", "car" },
    { "wheels:count", "3" },
    { "wheels:brand", "Blazin" },
    { "wheels:brand:type", "rally" },
    { "wheels:year", "2008" },
};

var memoryConfig = new MemoryConfigurationSource { InitialData = vehicleData };

builder.Configuration.Add(memoryConfig);

await builder.Build().RunAsync();
