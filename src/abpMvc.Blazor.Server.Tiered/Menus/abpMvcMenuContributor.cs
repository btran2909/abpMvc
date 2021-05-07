﻿using System;
using System.Threading.Tasks;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using abpMvc.Localization;
using Volo.Abp.Account.Localization;
using Volo.Abp.AuditLogging.Blazor.Menus;
using Volo.Abp.Identity.Pro.Blazor.Navigation;
using Volo.Abp.IdentityServer.Blazor.Navigation;
using Volo.Abp.LanguageManagement.Blazor.Menus;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TextTemplateManagement.Blazor.Menus;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;
using Volo.CmsKit.Pro.Admin.Web.Menus;
using Volo.Saas.Host.Blazor.Navigation;

namespace abpMvc.Blazor.Server.Tiered.Menus
{
    public class abpMvcMenuContributor : IMenuContributor
    {
        private readonly IConfiguration _configuration;

        public abpMvcMenuContributor(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
            else if (context.Menu.Name == StandardMenus.User)
            {
                await ConfigureUserMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<abpMvcResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    abpMvcMenus.Home,
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home",
                    order: 1
                )
            );
            
            /* Example nested menu definition:

            context.Menu.AddItem(
                new ApplicationMenuItem("Menu0", "Menu Level 0")
                .AddItem(new ApplicationMenuItem("Menu0.1", "Menu Level 0.1", url: "/test01"))
                .AddItem(
                    new ApplicationMenuItem("Menu0.2", "Menu Level 0.2")
                        .AddItem(new ApplicationMenuItem("Menu0.2.1", "Menu Level 0.2.1", url: "/test021"))
                        .AddItem(new ApplicationMenuItem("Menu0.2.2", "Menu Level 0.2.2")
                            .AddItem(new ApplicationMenuItem("Menu0.2.2.1", "Menu Level 0.2.2.1", "/test0221"))
                            .AddItem(new ApplicationMenuItem("Menu0.2.2.2", "Menu Level 0.2.2.2", "/test0222"))
                        )
                        .AddItem(new ApplicationMenuItem("Menu0.2.3", "Menu Level 0.2.3", url: "/test023"))
                        .AddItem(new ApplicationMenuItem("Menu0.2.4", "Menu Level 0.2.4", url: "/test024")
                            .AddItem(new ApplicationMenuItem("Menu0.2.4.1", "Menu Level 0.2.4.1", "/test0241"))
                    )
                    .AddItem(new ApplicationMenuItem("Menu0.2.5", "Menu Level 0.2.5", url: "/test025"))
                )
                .AddItem(new ApplicationMenuItem("Menu0.2", "Menu Level 0.2", url: "/test02"))
            );

            */
            
            context.Menu.SetSubItemOrder(SaasHostMenus.GroupName, 2);
            //CMS
            context.Menu.SetSubItemOrder(CmsKitProAdminMenus.GroupName, 3);

            //Administration
            var administration = context.Menu.GetAdministration();
            administration.Order = 4;

            //Administration->Identity
            administration.SetSubItemOrder(IdentityProMenus.GroupName, 1);

            //Administration->Identity Server
            administration.SetSubItemOrder(AbpIdentityServerMenuNames.GroupName, 2);

            //Administration->Language Management
            administration.SetSubItemOrder(LanguageManagementMenus.GroupName, 3);

            //Administration->Text Template Management
            administration.SetSubItemOrder(TextTemplateManagementMenus.GroupName, 4);

            //Administration->Audit Logs
            administration.SetSubItemOrder(AbpAuditLoggingMenus.GroupName, 5);

            //Administration->Settings
            administration.SetSubItemOrder(SettingManagementMenus.GroupName, 6);

            return Task.CompletedTask;
        }
        
        private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
        {
            var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();

            if (currentUser.IsAuthenticated)
            {
                var identityServerUrl = _configuration["AuthServer:Authority"] ?? "~";
                var uiResource = context.GetLocalizer<AbpUiResource>();
                var accountResource = context.GetLocalizer<AccountResource>();
                context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", accountResource["ManageYourProfile"], $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage", icon: "fa fa-cog", order: 1000, null, "_blank"));
                context.Menu.AddItem(new ApplicationMenuItem("Account.SecurityLogs", accountResource["MySecurityLogs"], $"{identityServerUrl.EnsureEndsWith('/')}Account/SecurityLogs", target: "_blank"));
                context.Menu.AddItem(new ApplicationMenuItem("Account.Logout", uiResource["Logout"], url: "~/Account/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000));
            }

            return Task.CompletedTask;
        }
    }
}
