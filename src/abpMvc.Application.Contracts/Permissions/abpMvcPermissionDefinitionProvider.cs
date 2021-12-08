using AbpMvc.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace AbpMvc.Permissions
{
    public class AbpMvcPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpMvcPermissions.GroupName);

            myGroup.AddPermission(AbpMvcPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
            myGroup.AddPermission(AbpMvcPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpMvcPermissions.MyPermission1, L("Permission:MyPermission1"));

            var bookPermission = myGroup.AddPermission(AbpMvcPermissions.Books.Default, L("Permission:Books"));
            bookPermission.AddChild(AbpMvcPermissions.Books.Create, L("Permission:Create"));
            bookPermission.AddChild(AbpMvcPermissions.Books.Edit, L("Permission:Edit"));
            bookPermission.AddChild(AbpMvcPermissions.Books.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpMvcResource>(name);
        }
    }
}