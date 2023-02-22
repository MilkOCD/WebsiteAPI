using Abp.Domain.Entities;
using System;

namespace TopfinAPI.Articles
{
    public class Article : Entity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string HashTag { get; set; }
        public DateTime CreationTime { get; set; }
        public Boolean? IsDelete { get; set; }
        public Boolean? DeleteTime { get; set; }
        //public List<string> NewImages { get; set; }
    }
}
