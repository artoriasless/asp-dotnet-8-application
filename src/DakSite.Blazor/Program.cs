using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DakSite.Blazor
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var application = await builder.AddApplicationAsync<DakSiteBlazorModule>(options =>
            {
                options.UseAutofac();
            });

            var host = builder.Build();

            await application.InitializeApplicationAsync(host.Services);

            await host.RunAsync();
        }
    }
}