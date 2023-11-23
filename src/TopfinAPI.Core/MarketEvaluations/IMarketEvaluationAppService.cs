using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TopfinAPI.MarketEvaluations
{
    public interface IMarketEvaluationAppService : IApplicationService
    {
        Task<MarketEvaluation> Get(int id);
        Task<List<MarketEvaluation>> GetAll();
        Task<MarketEvaluation> Create(MarketEvaluation input);
        Task<MarketEvaluation> Update(int id, MarketEvaluation input);
        Task Delete(int id);
    }
}
