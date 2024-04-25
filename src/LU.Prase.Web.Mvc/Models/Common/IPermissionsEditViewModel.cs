using System.Collections.Generic;
using LU.Prase.Roles.Dto;

namespace LU.Prase.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}