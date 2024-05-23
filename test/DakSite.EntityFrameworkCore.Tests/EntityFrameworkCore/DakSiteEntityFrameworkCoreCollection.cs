using Xunit;

namespace DakSite.EntityFrameworkCore;

[CollectionDefinition(DakSiteTestConsts.CollectionDefinitionName)]
public class DakSiteEntityFrameworkCoreCollection : ICollectionFixture<DakSiteEntityFrameworkCoreFixture>
{

}
