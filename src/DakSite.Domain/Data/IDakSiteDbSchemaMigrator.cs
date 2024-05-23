using System.Threading.Tasks;

namespace DakSite.Data;

public interface IDakSiteDbSchemaMigrator
{
    Task MigrateAsync();
}
