using FormulaOne.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace FormulaOne.Client.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void InjectClientServices(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped(
                sp =>
                new HttpClient
                {
                    BaseAddress = new Uri(configuration["FrontendUrl"] ?? "https://localhost:7159")
            });
        }
        public static void InjectClientServices(this IServiceCollection services, WebAssemblyHostConfiguration configuration)
        {
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped(
                sp =>
                new HttpClient
                {
                    BaseAddress = new Uri(configuration["FrontendUrl"] ?? "https://localhost:7159")
            });
        }
    }
}
