using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopfinAPI.Books
{
    public interface IBooksAppService : IApplicationService
    {
        Task<Book> Get(int id);
        Task<List<Book>> GetAll();
        Task<Book> Create(Book input);
        Task<Book> Update(int id, Book input);
        Task Delete(int id);
    }
}
