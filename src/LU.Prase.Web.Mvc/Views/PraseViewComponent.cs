using Abp.AspNetCore.Mvc.ViewComponents;

namespace LU.Prase.Web.Views
{
    public abstract class PraseViewComponent : AbpViewComponent
    {
        protected PraseViewComponent()
        {
            LocalizationSourceName = PraseConsts.LocalizationSourceName;
        }
    }
}
