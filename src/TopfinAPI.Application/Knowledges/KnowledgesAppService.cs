using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopfinAPI.Authorization;

namespace TopfinAPI.Knowledges
{
    public class KnowledgesAppService : ApplicationService, IKnowledgesAppService
    {
        private readonly IRepository<Knowledge> _knowledge;

        public KnowledgesAppService(IRepository<Knowledge> knowledge)
        {
            _knowledge = knowledge;
        }

        public async Task<Knowledge> Get(int id)
        {
            return await _knowledge.FirstOrDefaultAsync(id);
        }

        public async Task<List<Knowledge>> GetAll()
        {
            return await _knowledge.GetAllListAsync();
        }

        [AbpAuthorize(PermissionNames.Pages_Knowledges)]
        public async Task<Knowledge> Create(Knowledge input)
        {
            var entity = ObjectMapper.Map<Knowledge>(input);
            // Auto add creation time
            entity.CreationTime = DateTime.Now;

            return await _knowledge.InsertAsync(entity);
        }

        [AbpAuthorize(PermissionNames.Pages_Knowledges)]
        public async Task Delete(int id)
        {
            await _knowledge.DeleteAsync(id);
        }

        [AbpAuthorize(PermissionNames.Pages_Knowledges)]
        public async Task<Knowledge> Update(int id, Knowledge input)
        {
            var entity = await _knowledge.FirstOrDefaultAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(Knowledge), id);
            }

            entity.Title = input.Title;
            entity.Type = input.Type;
            entity.Content = input.Content;
            entity.ShortContent = input.ShortContent;
            entity.HashTag = input.HashTag;
            entity.ImageUrl = input.ImageUrl;
            // Auto add creation time
            entity.CreationTime = DateTime.Now;

            //ObjectMapper.Map(input, entity);
            await _knowledge.UpdateAsync(entity);

            return entity;
        }
    }
}
