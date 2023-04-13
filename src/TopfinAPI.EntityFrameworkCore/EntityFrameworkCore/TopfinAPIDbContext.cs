using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TopfinAPI.Authorization.Roles;
using TopfinAPI.Authorization.Users;
using TopfinAPI.MultiTenancy;
using TopfinAPI.Articles;
using TopfinAPI.Books;
using TopfinAPI.Knowledges;
using TopfinAPI.KnowledgeYoutubeUrls;

namespace TopfinAPI.EntityFrameworkCore
{
    public class TopfinAPIDbContext : AbpZeroDbContext<Tenant, Role, User, TopfinAPIDbContext>
    {
        public DbSet<Article> Articles { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Knowledge> Knowledges { get; set; }
        
        public DbSet<KnowledgeYoutubeUrl> KnowledgeYoutubeUrls { get; set; }
        /* Define a DbSet for each entity of the application */

        public TopfinAPIDbContext(DbContextOptions<TopfinAPIDbContext> options)
            : base(options)
        {
        }
    }
}
