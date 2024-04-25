using System.Collections.Generic;
using LU.Prase.Roles.Dto;

namespace LU.Prase.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
