using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TopfinAPI.AnalysisCenters
{
    public interface IAnalysisCenterAppService : IApplicationService
    {
        Task<AnalysisCenter> Get(int id);
        Task<List<AnalysisCenter>> GetAll();
        Task<AnalysisCenter> Create(AnalysisCenter input);
        Task<AnalysisCenter> Update(int id, AnalysisCenter input);
        Task Delete(int id);
    }
}
