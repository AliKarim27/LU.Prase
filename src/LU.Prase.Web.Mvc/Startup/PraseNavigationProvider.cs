using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using LU.Prase.Authorization;

namespace LU.Prase.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class PraseNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Machines,
                        L("Machines"),
                        url: "Machines",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Machines)
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PraseConsts.LocalizationSourceName);
        }
    }
}