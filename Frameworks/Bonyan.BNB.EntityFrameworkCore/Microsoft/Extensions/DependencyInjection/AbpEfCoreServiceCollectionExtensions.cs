using System;
using System.Linq;
using System.Reflection;
using Bonyan.BNB.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;


namespace Microsoft.Extensions.DependencyInjection;

public static class AbpEfCoreServiceCollectionExtensions
{
    public static IServiceCollection AddBnbDbContext<TDbContext>(
        this IServiceCollection services,
        Action<BnbDbContextOptions> optionsBuilder)
        where TDbContext : BnbDbContext<TDbContext>
    {
        services.AddMemoryCache();

     
        var options = new BnbDbContextOptions();
        
        optionsBuilder.Invoke(options);

        services.AddSingleton(options);

        
        services.TryAddTransient(DbContextOptionsFactory.Create<TDbContext>);
        services.AddDbContext<TDbContext>();
        return services;
    }
}
