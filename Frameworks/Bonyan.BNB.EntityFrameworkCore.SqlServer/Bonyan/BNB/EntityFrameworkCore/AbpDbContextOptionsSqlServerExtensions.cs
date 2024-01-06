using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Bonyan.BNB.EntityFrameworkCore;

public static class AbpDbContextOptionsSqlServerExtensions 
{
    public static void UseSqlServer(
        [NotNull] this BnbDbContextOptions options,
        string? connectionString,
        Action<SqlServerDbContextOptionsBuilder>? sqlServerOptionsAction = null)
    {
        options.Configure(context =>
        {
            context.UseSqlServer(connectionString,sqlServerOptionsAction);
        });
    }
    public static void UseSqlServer<TDbContext>(
        [NotNull] this BnbDbContextOptions options,
        string? connectionString,
        Action<SqlServerDbContextOptionsBuilder>? sqlServerOptionsAction = null)
        where TDbContext : BnbDbContext<TDbContext>
    {
        options.Configure<TDbContext>(context =>
        {
            context.UseSqlServer(connectionString,sqlServerOptionsAction);
        });
    }
}