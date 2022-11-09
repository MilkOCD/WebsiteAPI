using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TopfinAPI.EntityFrameworkCore;
using TopfinAPI.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace TopfinAPI.Web.Tests
{
    [DependsOn(
        typeof(TopfinAPIWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class TopfinAPIWebTestModule : AbpModule
    {
        public TopfinAPIWebTestModule(TopfinAPIEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TopfinAPIWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(TopfinAPIWebMvcModule).Assembly);
        }
    }
}