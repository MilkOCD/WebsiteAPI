using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TopfinAPI.Authorization;

namespace TopfinAPI
{
    [DependsOn(
        typeof(TopfinAPICoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TopfinAPIApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TopfinAPIAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TopfinAPIApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
