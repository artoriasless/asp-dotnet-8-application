using DakSite.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DakSite.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class DakSiteController : AbpControllerBase
{
    protected DakSiteController()
    {
        LocalizationResource = typeof(DakSiteResource);
    }
}
