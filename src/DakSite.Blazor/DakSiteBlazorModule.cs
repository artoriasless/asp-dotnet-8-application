using System;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Components.WebAssembly.LeptonXLiteTheme;
using Volo.Abp.AspNetCore.Components.Web.LeptonXLiteTheme.Themes.LeptonXLite;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.Autofac.WebAssembly;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Identity.Blazor.WebAssembly;
using Volo.Abp.Security.Claims;
using Volo.Abp.SettingManagement.Blazor.WebAssembly;
using Volo.Abp.TenantManagement.Blazor.WebAssembly;
using OpenIddict.Abstractions;
using Blazorise;
using Blazorise.AntDesign;
using Blazorise.Icons.FontAwesome;
using DakSite.Blazor.Menus;
using DakSite.Blazor.Services;

namespace DakSite.Blazor
{
    [DependsOn(
        typeof(AbpAutofacWebAssemblyModule),
        typeof(DakSiteHttpApiClientModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyLeptonXLiteThemeModule),
        typeof(AbpIdentityBlazorWebAssemblyModule),
        typeof(AbpTenantManagementBlazorWebAssemblyModule),
        typeof(AbpSettingManagementBlazorWebAssemblyModule)
    )]
    public class DakSiteBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var environment = context.Services.GetSingletonInstance<IWebAssemblyHostEnvironment>();
            var builder = context.Services.GetSingletonInstance<WebAssemblyHostBuilder>();

            builder.Services.AddScoped<MetaTagService>();
            builder.Services
                   .AddBlazorise(options =>
                   {
                       options.Immediate = true;
                   })
                   .AddAntDesignProviders()
                   .AddFontAwesomeIcons();


            ConfigureAuthentication(builder);
            ConfigureHttpClient(context, environment);
            ConfigureBlazorise(context);
            ConfigureRouter(context);
            ConfigureUI(builder);
            ConfigureMenu(context);
            ConfigureAutoMapper(context);
        }

        private void ConfigureRouter(ServiceConfigurationContext context)
        {
            Configure<AbpRouterOptions>(options =>
            {
                options.AppAssembly = typeof(DakSiteBlazorModule).Assembly;
            });
        }

        private void ConfigureMenu(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new DakSiteMenuContributor(context.Services.GetConfiguration()));
            });
        }

        private void ConfigureBlazorise(ServiceConfigurationContext context)
        {
            context.Services
                .AddAntDesignProviders()
                .AddFontAwesomeIcons();
        }

        private static void ConfigureAuthentication(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("AuthServer", options.ProviderOptions);
                options.UserOptions.NameClaim = OpenIddictConstants.Claims.Name;
                options.UserOptions.RoleClaim = OpenIddictConstants.Claims.Role;

                options.ProviderOptions.DefaultScopes.Add("DakSite");
                options.ProviderOptions.DefaultScopes.Add("roles");
                options.ProviderOptions.DefaultScopes.Add("email");
                options.ProviderOptions.DefaultScopes.Add("phone");
            });
        }

        private static void ConfigureUI(WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("#ApplicationContainer");
            builder.RootComponents.Add<HeadOutlet>("head::after");
        }

        private static void ConfigureHttpClient(ServiceConfigurationContext context, IWebAssemblyHostEnvironment environment)
        {
            context.Services.AddTransient(sp => new HttpClient
            {
                BaseAddress = new Uri(environment.BaseAddress)
            });
        }

        private void ConfigureAutoMapper(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<DakSiteBlazorModule>();
            });
        }
    }
}