using DakSite.Samples;
using Xunit;

namespace DakSite.EntityFrameworkCore.Applications;

[Collection(DakSiteTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<DakSiteEntityFrameworkCoreTestModule>
{

}
