using Volo.Abp.Modularity;

namespace DakSite;

[DependsOn(
    typeof(DakSiteDomainModule),
    typeof(DakSiteTestBaseModule)
)]
public class DakSiteDomainTestModule : AbpModule
{

}
