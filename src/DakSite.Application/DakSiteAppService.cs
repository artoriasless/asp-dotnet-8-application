using System;
using System.Collections.Generic;
using System.Text;
using DakSite.Localization;
using Volo.Abp.Application.Services;

namespace DakSite;

/* Inherit your application services from this class.
 */
public abstract class DakSiteAppService : ApplicationService
{
    protected DakSiteAppService()
    {
        LocalizationResource = typeof(DakSiteResource);
    }
}
