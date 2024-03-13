using Volo.Abp.Modularity;

namespace AbcYazilim.OnMuhasebe;

[DependsOn(
    typeof(OnMuhasebeDomainModule),
    typeof(OnMuhasebeTestBaseModule)
)]
public class OnMuhasebeDomainTestModule : AbpModule
{

}
