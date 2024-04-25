using Abp.Authorization;
using LU.Prase.Authorization.Roles;
using LU.Prase.Authorization.Users;

namespace LU.Prase.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
