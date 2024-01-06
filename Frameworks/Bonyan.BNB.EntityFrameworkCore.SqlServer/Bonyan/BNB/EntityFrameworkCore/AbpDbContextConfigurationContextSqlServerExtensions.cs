using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Bonyan.BNB.EntityFrameworkCore;

public static class BnbDbContextConfigurationContextSqlServerExtensions
{
    public static DbContextOptionsBuilder UseSqlServer(
        [NotNull] this BnbDbContextConfigurationContext context,
        string connectionString,
        Action<SqlServerDbContextOptionsBuilder>? sqlServerOptionsAction = null)
    {
        return context.DbContextOptions.UseSqlServer(connectionString, optionsBuilder =>
        {
            optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            sqlServerOptionsAction?.Invoke(optionsBuilder);
        });
    }
    
    
}
