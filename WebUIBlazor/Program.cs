using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebUIBlazor.Extensions;
using WebUIBlazor.Helpers;
using WebUIBlazor.Services.Abstract;
using WebUIBlazor.Services.Concrete;

namespace WebUIBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            // builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.ServiceConfiguration();

            /* builder.Services.AddScoped(x => {
                 var apiUrl = new Uri(builder.Configuration["apiUrl"]);

                 // use fake backend if "fakeBackend" is "true" in appsettings.json
                 if (builder.Configuration["backend"] == "true")
                     return new HttpClient(new BackendHandler()) { BaseAddress = apiUrl };

                 return new HttpClient() { BaseAddress = apiUrl };
             });*/
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44399/api/") });
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            // builder.Services.AddBlazoredLocalStorage(config => config.JsonSerializerOptions.WriteIndented = true);
            var host = builder.Build();
            var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
            await authenticationService.Initialize();
            await host.RunAsync();
        }
    }
}
