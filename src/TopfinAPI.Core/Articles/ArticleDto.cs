using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace TopfinAPI.Articles
{
    [AutoMapFrom(typeof(Article))]
    public class ArticleDto : EntityDto<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string HashTag { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
