using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using FluentFTP;
using System.Threading.Tasks;
using TopfinAPI.Authorization;
using System.Security.Authentication;
using System.Net;
using RestSharp;
using System.Text;
using RestSharp.Authenticators;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace TopfinAPI.Books
{
    public class BooksAppService : ApplicationService, IBooksAppService
    {
        private readonly IRepository<Book> _book;

        public BooksAppService(IRepository<Book> book)
        {
            _book = book;
        }

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

        public async Task<string> UploadImage(IFormFile file)
        {
            Account account = new Account(
                "dvidarzkp",
                "241215143565595",
                "WdttlU7wIWHahJHbsNLKgJhtdBY"
            );

            Cloudinary cloudinary = new Cloudinary(account);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                Transformation = new Transformation().Width(300).Height(450).Crop("fill"),
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            return uploadResult.SecureUrl.ToString();
        }
    }
}
