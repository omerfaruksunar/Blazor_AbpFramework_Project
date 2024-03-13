using AbcYazilim.OnMuhasebe.Samples;
using Xunit;

namespace AbcYazilim.OnMuhasebe.EntityFrameworkCore.Applications;

[Collection(OnMuhasebeTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<OnMuhasebeEntityFrameworkCoreTestModule>
{

}
