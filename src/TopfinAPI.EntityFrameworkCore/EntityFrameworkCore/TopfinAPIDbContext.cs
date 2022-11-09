using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TopfinAPI.Authorization.Roles;
using TopfinAPI.Authorization.Users;
using TopfinAPI.MultiTenancy;

namespace TopfinAPI.EntityFrameworkCore
{
    public class TopfinAPIDbContext : AbpZeroDbContext<Tenant, Role, User, TopfinAPIDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public TopfinAPIDbContext(DbContextOptions<TopfinAPIDbContext> options)
            : base(options)
        {
        }
    }
}
