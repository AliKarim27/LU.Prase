using LU.Prase.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace LU.Prase.Web.Controllers
{
    public class EmailController : PraseControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
