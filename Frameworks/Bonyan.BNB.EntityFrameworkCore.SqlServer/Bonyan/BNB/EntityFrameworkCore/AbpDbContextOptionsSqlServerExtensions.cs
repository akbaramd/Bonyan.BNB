using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Bonyan.BNB.EntityFrameworkCore;

public static class AbpDbContextOptionsSqlServerExtensions
{
    public static void UseSqlServer(
        [NotNull] this BnbDbContextOptions options,
        Action<SqlServerDbContextOptionsBuilder>? sqlServerOptionsAction = null)
    {
        options.Configure(context =>
        {
            context.UseSqlServer(sqlServerOptionsAction);
        });
    }

    public static void UseSqlServer<TDbContext>(
        [NotNull] this BnbDbContextOptions options,
        Action<SqlServerDbContextOptionsBuilder>? sqlServerOptionsAction = null)
        where TDbContext : BnbDbContext
    {
        options.Configure<TDbContext>(context =>
        {
            context.UseSqlServer(sqlServerOptionsAction);
        });
    }
}