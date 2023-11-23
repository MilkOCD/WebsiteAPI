using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopfinAPI.Authorization;
using TopfinAPI.MarketEvaluations;

namespace TopfinAPI.MarketEvaluations
{
    public class MarketEvaluationsAppService : ApplicationService, IMarketEvaluationAppService
    {
        private readonly IRepository<MarketEvaluation> _marketEvaluation;

        public MarketEvaluationsAppService(IRepository<MarketEvaluation> marketEvaluation)
        {
            _marketEvaluation = marketEvaluation;
        }

        [AbpAuthorize(PermissionNames.Pages_MarketEvaluations)]
        public async Task<MarketEvaluation> Create(MarketEvaluation input)
        {
            var creationDataReceived = input;
            creationDataReceived.CreationTime = DateTime.Now;

            return await _marketEvaluation.InsertAsync(creationDataReceived);
        }

        public async Task<MarketEvaluation> Get(int id)
        {
            return await _marketEvaluation.FirstOrDefaultAsync(id);
        }

        public async Task<List<MarketEvaluation>> GetAll()
        {
            return await _marketEvaluation.GetAllListAsync();
        }

        public async Task<List<MarketEvaluation>> GetAllByType(String type, int pageNumber, int pageSize)
        {
            // return await _marketEvaluation.GetAll().Where(d => d.Type == type).ToListAsync();
            return await _marketEvaluation.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        [AbpAuthorize(PermissionNames.Pages_MarketEvaluations)]
        public async Task<MarketEvaluation> Update(int id, MarketEvaluation input)
        {
            var entity = await _marketEvaluation.FirstOrDefaultAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(MarketEvaluation), id);
            }

            entity.Title = input.Title;
            entity.Type = input.Type;
            entity.Content = input.Content;
            entity.ShortContent = input.ShortContent;
            entity.PdfUrl = input.PdfUrl;
            entity.ImageUrl = input.ImageUrl;
            entity.CreationTime = DateTime.Now;

            await _marketEvaluation.UpdateAsync(entity);

            return entity;
        }

        [AbpAuthorize(PermissionNames.Pages_MarketEvaluations)]
        public async Task Delete(int id)
        {
            await _marketEvaluation.DeleteAsync(id);
        }
    }
}
