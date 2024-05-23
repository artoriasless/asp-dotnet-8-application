using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace DakSite.Data;

/* This is used if database provider does't define
 * IDakSiteDbSchemaMigrator implementation.
 */
public class NullDakSiteDbSchemaMigrator : IDakSiteDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
