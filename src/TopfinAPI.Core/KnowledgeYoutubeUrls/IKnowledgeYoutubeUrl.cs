using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopfinAPI.KnowledgeYoutubeUrls
{
    public interface IKnowledgeYoutubeUrls : IApplicationService
    {
        Task<KnowledgeYoutubeUrl> Get(int id);
        Task<List<KnowledgeYoutubeUrl>> GetAll();
        Task<KnowledgeYoutubeUrl> Create(KnowledgeYoutubeUrl input);
        Task<KnowledgeYoutubeUrl> Update(int id, KnowledgeYoutubeUrl input);
        Task Delete(int id);
    }
}
