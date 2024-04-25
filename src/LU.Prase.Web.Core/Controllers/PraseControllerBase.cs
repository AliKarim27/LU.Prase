using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace LU.Prase.Controllers
{
    public abstract class PraseControllerBase: AbpController
    {
        protected PraseControllerBase()
        {
            LocalizationSourceName = PraseConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
