using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUIBlazor.Services.Abstract;
using WebUIBlazor.Services.Concrete;

namespace WebUIBlazor.Extensions
{
    public static class ServiceExtension
    {
        public static void ServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHobbyService, HobbyService>();
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ILocalStorageService, LocalStorageService>();
            services.AddSingleton<HubService>();
        }
    }
}
