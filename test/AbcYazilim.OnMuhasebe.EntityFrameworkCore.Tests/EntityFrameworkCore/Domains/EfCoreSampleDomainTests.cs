using AbcYazilim.OnMuhasebe.Samples;
using Xunit;

namespace AbcYazilim.OnMuhasebe.EntityFrameworkCore.Domains;

[Collection(OnMuhasebeTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<OnMuhasebeEntityFrameworkCoreTestModule>
{

}
