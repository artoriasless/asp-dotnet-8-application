using DakSite.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace DakSite.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(DakSiteEntityFrameworkCoreModule),
    typeof(DakSiteApplicationContractsModule)
    )]
public class DakSiteDbMigratorModule : AbpModule
{
}
