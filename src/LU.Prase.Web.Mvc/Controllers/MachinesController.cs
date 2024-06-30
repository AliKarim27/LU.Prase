using Abp.Application.Services.Dto;
using LU.Prase.Controllers;
using LU.Prase.Machines;
using LU.Prase.Machines.Dto;
using LU.Prase.Web.Models.Roles;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LU.Prase.Web.Controllers
{
    public class MachinesController : PraseControllerBase
    {

        private readonly MachineAppService _machineAppService;

        public MachinesController(MachineAppService machineAppService)
        {
            _machineAppService = machineAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> EditModal(int machineId)
        {
            var output = await _machineAppService.GetAsync(new EntityDto<long> { Id = machineId });
            output.AllSections = await _machineAppService.GetSectionsAsync();
            return PartialView("_EditModal", output);
        }
    }
}
