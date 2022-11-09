﻿using System.Threading.Tasks;
using Abp.Application.Services;
using TopfinAPI.Sessions.Dto;

namespace TopfinAPI.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
