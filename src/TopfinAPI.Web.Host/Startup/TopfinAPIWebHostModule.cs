using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TopfinAPI.Configuration;

namespace TopfinAPI.Web.Host.Startup
{
    [DependsOn(
       typeof(TopfinAPIWebCoreModule))]
    public class TopfinAPIWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TopfinAPIWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TopfinAPIWebHostModule).GetAssembly());
        }
    }
}
