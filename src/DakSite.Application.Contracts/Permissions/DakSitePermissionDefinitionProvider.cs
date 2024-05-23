using DakSite.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DakSite.Permissions;

public class DakSitePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(DakSitePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(DakSitePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DakSiteResource>(name);
    }
}
