using System.Threading.Tasks;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DakSite.Blazor;

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

        builder.Services
               .AddBlazorise(options =>
               {
                   options.Immediate = true;
               })
               .AddBootstrap5Providers()
               .AddFontAwesomeIcons();

        await application.InitializeApplicationAsync(host.Services);

        await host.RunAsync();
    }
}
