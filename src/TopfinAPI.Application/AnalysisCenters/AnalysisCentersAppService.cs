using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopfinAPI.Authorization;

namespace TopfinAPI.AnalysisCenters
{
    public class AnalysisCentersAppService : ApplicationService, IAnalysisCenterAppService
    {
        private readonly IRepository<AnalysisCenter> _analysisCenter;

        public AnalysisCentersAppService(IRepository<AnalysisCenter> analysisCenter)
        {
            _analysisCenter = analysisCenter;
        }

        [AbpAuthorize(PermissionNames.Pages_AnalysisCenters)]
        public async Task<AnalysisCenter> Create(AnalysisCenter input)
        {
            var creationDataReceived = input;
            creationDataReceived.CreationTime = DateTime.Now;

            return await _analysisCenter.InsertAsync(creationDataReceived);
        }

        public async Task<AnalysisCenter> Get(int id)
        {
            return await _analysisCenter.FirstOrDefaultAsync(id);
        }

        public async Task<List<AnalysisCenter>> GetAll()
        {
            return await _analysisCenter.GetAllListAsync();
        }

        [AbpAuthorize(PermissionNames.Pages_AnalysisCenters)]
        public async Task<AnalysisCenter> Update(int id, AnalysisCenter input)
        {
            var entity = await _analysisCenter.FirstOrDefaultAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(AnalysisCenter), id);
            }

            entity.Title = input.Title;
            entity.Type = input.Type;
            entity.Content = input.Content;
            entity.ShortContent = input.ShortContent;
            entity.PdfUrl = input.PdfUrl;
            entity.ImageUrl = input.ImageUrl;
            entity.CreationTime = DateTime.Now;

            await _analysisCenter.UpdateAsync(entity);

            return entity;
        }

        [AbpAuthorize(PermissionNames.Pages_AnalysisCenters)]
        public async Task Delete(int id)
        {
            await _analysisCenter.DeleteAsync(id);
        }
    }
}
