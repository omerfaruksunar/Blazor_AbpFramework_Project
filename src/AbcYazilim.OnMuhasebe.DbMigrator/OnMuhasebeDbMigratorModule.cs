using AbcYazilim.OnMuhasebe.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbcYazilim.OnMuhasebe.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(OnMuhasebeEntityFrameworkCoreModule),
    typeof(OnMuhasebeApplicationContractsModule)
    )]
public class OnMuhasebeDbMigratorModule : AbpModule
{
}
