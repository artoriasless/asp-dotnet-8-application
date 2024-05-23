using Volo.Abp.Modularity;

namespace DakSite;

/* Inherit from this class for your domain layer tests. */
public abstract class DakSiteDomainTestBase<TStartupModule> : DakSiteTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
