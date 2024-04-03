using FormulaOne.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FormulaOne.Client.Extensions;

namespace FormulaOne.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.InjectClientServices(builder.Configuration);


            await builder.Build().RunAsync();
        }
    }
}
