using System.Threading.Tasks;
using Abp.Application.Services;
using TopfinAPI.Authorization.Accounts.Dto;

namespace TopfinAPI.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
