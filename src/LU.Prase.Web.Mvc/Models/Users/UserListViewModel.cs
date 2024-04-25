using System.Collections.Generic;
using LU.Prase.Roles.Dto;

namespace LU.Prase.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
