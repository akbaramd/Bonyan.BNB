using Bonyan.BNB.EntityFrameworkCore;

namespace Microsoft.EntityFrameworkCore;

public static class AbpSqlServerModelBuilderExtensions
{
    public static void UseSqlServer(
        this ModelBuilder modelBuilder)
    {
        modelBuilder.SetDatabaseProvider(EfCoreDatabaseProvider.SqlServer);
    }
}