using AbcYazilim.OnMuhasebe.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AbcYazilim.OnMuhasebe.Blazor;

public abstract class OnMuhasebeComponentBase : AbpComponentBase
{
    protected OnMuhasebeComponentBase()
    {
        LocalizationResource = typeof(OnMuhasebeResource);
    }
}
