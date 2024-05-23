using Volo.Abp.Modularity;

namespace DakSite;

[DependsOn(
    typeof(DakSiteApplicationModule),
    typeof(DakSiteDomainTestModule)
)]
public class DakSiteApplicationTestModule : AbpModule
{

}
