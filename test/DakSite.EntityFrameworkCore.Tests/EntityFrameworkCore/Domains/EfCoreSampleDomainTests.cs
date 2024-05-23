using DakSite.Samples;
using Xunit;

namespace DakSite.EntityFrameworkCore.Domains;

[Collection(DakSiteTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<DakSiteEntityFrameworkCoreTestModule>
{

}
