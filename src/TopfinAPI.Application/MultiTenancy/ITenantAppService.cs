using Abp.Application.Services;
using TopfinAPI.MultiTenancy.Dto;

namespace TopfinAPI.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

