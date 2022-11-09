using System.Threading.Tasks;
using TopfinAPI.Configuration.Dto;

namespace TopfinAPI.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
