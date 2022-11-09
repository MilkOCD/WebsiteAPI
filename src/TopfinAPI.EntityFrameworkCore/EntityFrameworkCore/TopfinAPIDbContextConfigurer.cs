using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TopfinAPI.EntityFrameworkCore
{
    public static class TopfinAPIDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TopfinAPIDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TopfinAPIDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
