using Abp.Domain.Entities;
using System;

namespace TopfinAPI.KnowledgeYoutubeUrls
{
    public class KnowledgeYoutubeUrl : Entity<int>
    {
        public string YoutubeUrl { get; set; }
    }
}
