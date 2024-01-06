using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bonyan.BNB.EntityFrameworkCore;

public class BnbDbContextConfigurationContext
{
    public IServiceProvider ServiceProvider { get; }

    public DbContextOptionsBuilder DbContextOptions { get; protected set; }

    public BnbDbContextConfigurationContext(
         IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        DbContextOptions = new DbContextOptionsBuilder()
            .UseLoggerFactory(serviceProvider.GetRequiredService<ILoggerFactory>())
            .UseApplicationServiceProvider(serviceProvider);
    }
}

public class BnbDbContextConfigurationContext<TDbContext> : BnbDbContextConfigurationContext
    where TDbContext : BnbDbContext<TDbContext>
{
    public new DbContextOptionsBuilder<TDbContext> DbContextOptions => (DbContextOptionsBuilder<TDbContext>)base.DbContextOptions;

    public BnbDbContextConfigurationContext(
        IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
        base.DbContextOptions = new DbContextOptionsBuilder<TDbContext>()
            .UseLoggerFactory(serviceProvider.GetRequiredService<ILoggerFactory>())
            .UseApplicationServiceProvider(serviceProvider); ;
    }
}