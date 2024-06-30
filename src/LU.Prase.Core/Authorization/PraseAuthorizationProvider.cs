using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace LU.Prase.Authorization
{
    public class PraseAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Machines, L("Machines"));
            context.CreatePermission(PermissionNames.Pages_CreateMachines, L("CreateMachine"));
            context.CreatePermission(PermissionNames.Pages_EditMachines, L("EditMachine"));
            context.CreatePermission(PermissionNames.Pages_DeleteMachines, L("DeleteMachine")); 
            context.CreatePermission(PermissionNames.Pages_Departements, L("Departements"));
            context.CreatePermission(PermissionNames.Pages_CreateDepartements, L("CreateDepartement"));
            context.CreatePermission(PermissionNames.Pages_EditDepartements, L("EditDepartement"));
            context.CreatePermission(PermissionNames.Pages_DeleteDepartements, L("DeleteDepartement"));
            context.CreatePermission(PermissionNames.Pages_Sections, L("Sections"));
            context.CreatePermission(PermissionNames.Pages_CreateSections, L("CreateSection"));
            context.CreatePermission(PermissionNames.Pages_EditSections, L("EditSection"));
            context.CreatePermission(PermissionNames.Pages_DeleteSections, L("DeleteSection"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PraseConsts.LocalizationSourceName);
        }
    }
}
