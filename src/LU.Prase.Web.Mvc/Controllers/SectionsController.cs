using Abp.Application.Services.Dto;
using LU.Prase.Controllers;
using LU.Prase.Department;
using LU.Prase.Sections;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LU.Prase.Web.Controllers
{
    public class SectionsController : PraseControllerBase
    {
        private readonly SectionAppService _sectionAppService;
        private readonly DepartementAppService _departementAppService;

        public SectionsController(SectionAppService sectionAppService, DepartementAppService departementAppService)
        {
            _sectionAppService = sectionAppService;
            _departementAppService = departementAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> EditModal(int sectionId)
        {
            var output = await _sectionAppService.GetAsync(new EntityDto<long> { Id = sectionId });
            output.AllResponsibles = await _sectionAppService.GetAllResponsiblesAsync();
            output.AllDepartements = await _sectionAppService.GetDepartementsAsync();
            return PartialView("_EditModal", output);
        }
    }
}
