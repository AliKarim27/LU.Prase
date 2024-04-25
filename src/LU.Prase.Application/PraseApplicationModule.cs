using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LU.Prase.Authorization;

namespace LU.Prase
{
    [DependsOn(
        typeof(PraseCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PraseApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<PraseAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(PraseApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
