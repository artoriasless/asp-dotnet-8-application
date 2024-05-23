using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace DakSite.Blazor;

[Dependency(ReplaceServices = true)]
public class DakSiteBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "DakSite";
}
