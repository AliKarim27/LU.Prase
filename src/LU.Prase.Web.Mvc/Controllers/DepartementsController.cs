using Abp.Application.Services.Dto;
using LU.Prase.Controllers;
using LU.Prase.Department;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LU.Prase.Web.Controllers
{
    public class DepartementsController : PraseControllerBase
    {
        private readonly DepartementAppService _departementAppService;

        public DepartementsController(DepartementAppService departementAppService)
        {
            _departementAppService = departementAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> EditModal(int departementId)
        {
            var output = await _departementAppService.GetAsync(new EntityDto<long> { Id = departementId });
            output.AllResponsibles = await _departementAppService.GetAllResponsiblesAsync();
            return PartialView("_EditModal", output);
        }
    }
}
