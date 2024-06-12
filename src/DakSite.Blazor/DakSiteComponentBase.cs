using DakSite.Localization;
using Volo.Abp.AspNetCore.Components;

namespace DakSite.Blazor
{
    public abstract class DakSiteComponentBase : AbpComponentBase
    {
        protected DakSiteComponentBase()
        {
            LocalizationResource = typeof(DakSiteResource);
        }
    }
}