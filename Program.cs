using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BasicLoginPage;

var Builder = WebAssemblyHostBuilder.CreateDefault(args);
Builder.RootComponents.Add<App>("#app");
Builder.RootComponents.Add<HeadOutlet>("head::after");

Builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(Builder.HostEnvironment.BaseAddress) });

await Builder.Build().RunAsync();
