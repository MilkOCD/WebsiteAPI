using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TopfinAPI.Configuration.Dto;

namespace TopfinAPI.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TopfinAPIAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
