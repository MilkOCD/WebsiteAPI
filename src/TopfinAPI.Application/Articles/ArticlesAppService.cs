using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopfinAPI.Authorization;

namespace TopfinAPI.Articles
{
    //[AbpAuthorize(PermissionNames.Pages_Articles)]
    public class ArticlesAppService : ApplicationService, IApplicationService
    {
        private readonly IRepository<Article> _article;

        public ArticlesAppService(IRepository<Article> article)
        {
            _article = article;
        }

        [AbpAuthorize(PermissionNames.Pages_Articles)]
        public async Task<Article> Create(Article input)
        {
            // Create entity
            var entity = ObjectMapper.Map<Article>(input);
            // Auto add creation time
            entity.CreationTime = DateTime.Now;

            return await _article.InsertAsync(entity);
        }

        public async Task<List<Article>> GetAll()
        {
            return await _article.GetAllListAsync();
        }

        public async Task<Article> Get(int id)
        {
            return await _article.FirstOrDefaultAsync(id);
        }

        // UpdateModel là một class mô tả các thuộc tính của record cần cập nhật
        [AbpAuthorize(PermissionNames.Pages_Articles)]
        public async Task Update(int id, Article input)
        {
            var existingRecord = await _article.GetAsync(id);

            if (existingRecord == null)
            {
                throw new Exception("Record not found");
            }

            existingRecord.Title = input.Title;
            existingRecord.Description = input.Description;
            existingRecord.HashTag = input.HashTag;
            existingRecord.CreationTime = new DateTime();

            await _article.UpdateAsync(existingRecord);
        }

        [AbpAuthorize(PermissionNames.Pages_Articles)]
        [HttpDelete]
        public async Task Delete(int id)
        {
            var existingRecord = await _article.GetAsync(id);
            if (existingRecord == null)
            {
                throw new Exception("Record not found");
            };

            await _article.DeleteAsync(existingRecord);
        }

        [AbpAuthorize(PermissionNames.Pages_Articles)]
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
                Transformation = new Transformation().Width(500).Height(333).Crop("fill"),
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            return uploadResult.SecureUrl.ToString();
        }
    }
}
