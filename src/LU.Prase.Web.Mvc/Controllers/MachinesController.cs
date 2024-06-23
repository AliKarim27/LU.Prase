using Abp.Application.Services.Dto;
using LU.Prase.Controllers;
using LU.Prase.Web.Models.Roles;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LU.Prase.Web.Controllers
{
    public class MachinesController : PraseControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> EditModal(int roleId)
        {
            var output = await _roleAppService.GetRoleForEdit(new EntityDto(roleId));
            var model = ObjectMapper.Map<EditRoleModalViewModel>(output);

            return PartialView("_EditModal", model);
        }
    }
}
