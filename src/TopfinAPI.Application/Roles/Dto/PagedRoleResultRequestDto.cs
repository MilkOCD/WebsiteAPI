using Abp.Application.Services.Dto;

namespace TopfinAPI.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

