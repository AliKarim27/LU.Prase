using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LU.Prase.EntityFrameworkCore;
using LU.Prase.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace LU.Prase.Web.Tests
{
    [DependsOn(
        typeof(PraseWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class PraseWebTestModule : AbpModule
    {
        public PraseWebTestModule(PraseEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PraseWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(PraseWebMvcModule).Assembly);
        }
    }
}