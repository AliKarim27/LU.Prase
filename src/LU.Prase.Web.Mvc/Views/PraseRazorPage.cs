using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace LU.Prase.Web.Views
{
    public abstract class PraseRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected PraseRazorPage()
        {
            LocalizationSourceName = PraseConsts.LocalizationSourceName;
        }
    }
}
