using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LU.Prase.Controllers;

namespace LU.Prase.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : PraseControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
