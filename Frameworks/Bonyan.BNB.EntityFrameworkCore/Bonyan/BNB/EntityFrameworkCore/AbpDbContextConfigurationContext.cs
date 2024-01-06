using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bonyan.BNB.EntityFrameworkCore;

public class AbpDbContextConfigurationContext
{
    public IServiceProvider ServiceProvider { get; }

    public string ConnectionString { get; }

    public string? ConnectionStringName { get; }

    public DbConnection? ExistingConnection { get; }

    public DbContextOptionsBuilder DbContextOptions { get; protected set; }

    public AbpDbContextConfigurationContext(
         string connectionString,
         IServiceProvider serviceProvider,
         string? connectionStringName,
         DbConnection? existingConnection)
    {
        ConnectionString = connectionString;
        ServiceProvider = serviceProvider;
        ConnectionStringName = connectionStringName;
        ExistingConnection = existingConnection;

        DbContextOptions = new DbContextOptionsBuilder()
            .UseLoggerFactory(serviceProvider.GetRequiredService<ILoggerFactory>())
            .UseApplicationServiceProvider(serviceProvider);
    }
}

public class AbpDbContextConfigurationContext<TDbContext> : AbpDbContextConfigurationContext
    where TDbContext : BnbDbContext
{
    public new DbContextOptionsBuilder<TDbContext> DbContextOptions => (DbContextOptionsBuilder<TDbContext>)base.DbContextOptions;

    public AbpDbContextConfigurationContext(
        string connectionString,
        IServiceProvider serviceProvider,
        string? connectionStringName,
        DbConnection? existingConnection)
        : base(
            connectionString,
            serviceProvider,
            connectionStringName,
            existingConnection)
    {
        base.DbContextOptions = new DbContextOptionsBuilder<TDbContext>()
            .UseLoggerFactory(serviceProvider.GetRequiredService<ILoggerFactory>())
            .UseApplicationServiceProvider(serviceProvider); ;
    }
}