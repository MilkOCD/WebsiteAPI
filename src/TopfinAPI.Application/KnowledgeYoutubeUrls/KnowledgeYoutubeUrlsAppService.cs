using Abp.Application.Services;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TopfinAPI.KnowledgeYoutubeUrls
{
    public class KnowledgeYoutubeUrlsAppService : ApplicationService, IKnowledgeYoutubeUrls
    {
        private readonly IRepository<KnowledgeYoutubeUrl> _knowledgeYoutubeUrl;

        public KnowledgeYoutubeUrlsAppService(IRepository<KnowledgeYoutubeUrl> knowledgeYoutubeUrl)
        {
            _knowledgeYoutubeUrl = knowledgeYoutubeUrl;
        }

        public async Task<KnowledgeYoutubeUrl> Get(int id)
        {
            return await _knowledgeYoutubeUrl.FirstOrDefaultAsync(id);
        }

        public async Task<List<KnowledgeYoutubeUrl>> GetAll()
        {
            return await _knowledgeYoutubeUrl.GetAllListAsync();
        }

        public async Task<KnowledgeYoutubeUrl> Create(KnowledgeYoutubeUrl input)
        {
            var entity = ObjectMapper.Map<KnowledgeYoutubeUrl>(input);

            return await _knowledgeYoutubeUrl.InsertAsync(entity);
        }

        public async Task Delete(int id)
        {
            await _knowledgeYoutubeUrl.DeleteAsync(id);
        }

        public async Task<KnowledgeYoutubeUrl> Update(int id, KnowledgeYoutubeUrl input)
        {
            var entity = await _knowledgeYoutubeUrl.FirstOrDefaultAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(KnowledgeYoutubeUrl), id);
            }

            //ObjectMapper.Map(input, entity);
            entity.YoutubeUrl = input.YoutubeUrl;

            await _knowledgeYoutubeUrl.UpdateAsync(entity);

            return entity;
        }
    }
}
