using ChatApp.WASM;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:34352/api") });




builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsAllowAll",
        builder =>
        {
            builder.AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true);

        });
});


//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
