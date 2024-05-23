using Volo.Abp.Modularity;

namespace DakSite;

public abstract class DakSiteApplicationTestBase<TStartupModule> : DakSiteTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
