using JFP.Client;
using JFP.Server.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure services
builder.Services.AddMudServices();
builder.Services.AddHttpClient("Project.ServerAPI", client => client.BaseAddress = new Uri("https://localhost:63993"));
builder.Services.AddRestServices();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Project.ServerAPI"));


await builder.Build().RunAsync();
