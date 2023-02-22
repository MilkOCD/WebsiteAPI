using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopfinAPI.Authorization;

namespace TopfinAPI.Books
{
    public class BooksAppService : ApplicationService, IBooksAppService
    {
        private readonly IRepository<Book> _book;

        public BooksAppService(IRepository<Book> book)
        {
            _book = book;
        }

        [AbpAuthorize(PermissionNames.Pages_Books)]
        public async Task<Book> Create(Book input)
        {
            var entity = ObjectMapper.Map<Book>(input);

            return await _book.InsertAsync(entity);
        }

        [AbpAuthorize(PermissionNames.Pages_Books)]
        public async Task Delete(int id)
        {
            await _book.DeleteAsync(id);
        }

        public async Task<Book> Get(int id)
        {
            return await _book.FirstOrDefaultAsync(id);
        }

        public async Task<List<Book>> GetAll()
        {
            return await _book.GetAllListAsync();
        }

        [AbpAuthorize(PermissionNames.Pages_Books)]
        public Task<Book> Update(int id, Book input)
        {
            throw new NotImplementedException();
        }
    }
}
