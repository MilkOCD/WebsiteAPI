using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TopfinAPI.Authorization.Roles;
using TopfinAPI.Authorization.Users;
using TopfinAPI.MultiTenancy;
using TopfinAPI.Articles;
using TopfinAPI.Books;

namespace TopfinAPI.EntityFrameworkCore
{
    public class TopfinAPIDbContext : AbpZeroDbContext<Tenant, Role, User, TopfinAPIDbContext>
    {
        public DbSet<Article> Articles { get; set; }

        public DbSet<Book> Books { get; set; }
        /* Define a DbSet for each entity of the application */

        public TopfinAPIDbContext(DbContextOptions<TopfinAPIDbContext> options)
            : base(options)
        {
        }
    }
}
