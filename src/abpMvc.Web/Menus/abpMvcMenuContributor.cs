using System.Threading.Tasks;
using abpMvc.Localization;
using abpMvc.Permissions;
using Volo.Abp.AuditLogging.Web.Navigation;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.IdentityServer.Web.Navigation;
using Volo.Abp.LanguageManagement.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TextTemplateManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
//using Volo.CmsKit.Pro.Admin.Web.Menus;
using Volo.Saas.Host.Navigation;

namespace abpMvc.Web.Menus
{
    public class abpMvcMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<abpMvcResource>();

            //Home
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    abpMvcMenus.Home,
                    l["Menu:Home"],
                    "~/",
                    icon: "fa fa-home",
                    order: 1
                )
            );

            //HostDashboard
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    abpMvcMenus.HostDashboard,
                    l["Menu:Dashboard"],
                    "~/HostDashboard",
                    icon: "fa fa-line-chart",
                    order: 2,
                    requiredPermissionName: abpMvcPermissions.Dashboard.Host
                )
            );

            //TenantDashboard
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    abpMvcMenus.TenantDashboard,
                    l["Menu:Dashboard"],
                    "~/Dashboard",
                    icon: "fa fa-line-chart",
                    order: 2,
                    requiredPermissionName: abpMvcPermissions.Dashboard.Tenant
                )
            );

            context.Menu.SetSubItemOrder(SaasHostMenuNames.GroupName, 3);
            //CMS
            //context.Menu.SetSubItemOrder(CmsKitProAdminMenus.GroupName, 4);

            //Administration
            var administration = context.Menu.GetAdministration();
            administration.Order = 5;

            //Administration->Identity
            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);

            //Administration->Identity Server
            administration.SetSubItemOrder(AbpIdentityServerMenuNames.GroupName, 2);

            //Administration->Language Management
            administration.SetSubItemOrder(LanguageManagementMenuNames.GroupName, 3);

            //Administration->Text Template Management
            administration.SetSubItemOrder(TextTemplateManagementMainMenuNames.GroupName, 4);

            //Administration->Audit Logs
            administration.SetSubItemOrder(AbpAuditLoggingMainMenuNames.GroupName, 5);

            //Administration->Settings
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 6);

            return Task.CompletedTask;
        }
    }
}
