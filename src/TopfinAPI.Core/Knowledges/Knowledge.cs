﻿using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopfinAPI.Knowledges
{
    public class Knowledge : Entity<int>
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public string ShortContent { get; set; }
        public string HashTag { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreationTime { get; set; }
        public Boolean? IsDelete { get; set; }
        public Boolean? DeleteTime { get; set; }
    }
}
