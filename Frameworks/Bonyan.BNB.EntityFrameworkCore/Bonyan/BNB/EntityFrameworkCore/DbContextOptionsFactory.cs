using Bonyan.Bnb.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Bonyan.BNB.EntityFrameworkCore;

public static class DbContextOptionsFactory
{
    public static DbContextOptions<TDbContext> Create<TDbContext>(IServiceProvider serviceProvider)
        where TDbContext : BnbDbContext<TDbContext>
    {
       
        
        var context = new BnbDbContextConfigurationContext<TDbContext>(
            serviceProvider);

        var options = GetDbContextOptions(serviceProvider);

        PreConfigure(options, context);
        Configure(options, context);

        return context.DbContextOptions.Options;
    }

    private static void PreConfigure<TDbContext>(
        BnbDbContextOptions options,
        BnbDbContextConfigurationContext<TDbContext> context)
        where TDbContext : BnbDbContext<TDbContext>
    {
        foreach (var defaultPreConfigureAction in options.DefaultPreConfigureActions)
        {
            defaultPreConfigureAction.Invoke(context);
        }

        var preConfigureActions = options.PreConfigureActions.GetOrDefault(typeof(TDbContext));
        if (!preConfigureActions.IsNullOrEmpty())
        {
            foreach (var preConfigureAction in preConfigureActions!)
            {
                ((Action<BnbDbContextConfigurationContext<TDbContext>>)preConfigureAction).Invoke(context);
            }
        }
    }

    private static void Configure<TDbContext>(
        BnbDbContextOptions options,
        BnbDbContextConfigurationContext<TDbContext> context)
        where TDbContext : BnbDbContext<TDbContext>
    {
        var configureAction = options.ConfigureActions.GetOrDefault(typeof(TDbContext));
        if (configureAction != null)
        {
            ((Action<BnbDbContextConfigurationContext<TDbContext>>)configureAction).Invoke(context);
        }
        else if (options.DefaultConfigureAction != null)
        {
            options.DefaultConfigureAction.Invoke(context);
        }
        else
        {
            throw new Exception(
                $"No configuration found for {typeof(DbContext).AssemblyQualifiedName}! Use services.Configure<AbpDbContextOptions>(...) to configure it.");
        }
    }

    private static BnbDbContextOptions GetDbContextOptions(IServiceProvider serviceProvider)
       
    {
        return serviceProvider.GetRequiredService<BnbDbContextOptions>();
    }

   

}
