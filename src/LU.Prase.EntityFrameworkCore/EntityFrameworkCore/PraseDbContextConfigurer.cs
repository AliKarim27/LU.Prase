using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LU.Prase.EntityFrameworkCore
{
    public static class PraseDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PraseDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PraseDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
