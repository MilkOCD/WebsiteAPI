using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopfinAPI.Knowledges
{
    public interface IKnowledgesAppService : IApplicationService
    {
        Task<Knowledge> Get(int id);
        Task<List<Knowledge>> GetAll();
        Task<Knowledge> Create(Knowledge input);
        Task<Knowledge> Update(int id, Knowledge input);
        Task Delete(int id);
    }
}
