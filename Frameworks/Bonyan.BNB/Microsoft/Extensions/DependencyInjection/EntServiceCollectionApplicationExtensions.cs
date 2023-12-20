using Bonyan.Bnb;
using Bonyan.Bnb.Modularity;

namespace Microsoft.Extensions.DependencyInjection;

public static class BnbServiceCollectionApplicationExtensions
{
    public static Task<IBnbApplicationWithExternalServiceProvider> AddApplicationAsync<TStartupModule>(
        this IServiceCollection services,
        Action<BnbApplicationCreationOptions>? action = null)
        where TStartupModule : IBnbModule
    {
        return services.AddApplicationAsync(typeof(TStartupModule),action);
    }

    public static Task<IBnbApplicationWithExternalServiceProvider> AddApplicationAsync(
        this IServiceCollection services,
        Type startupModuleType,
        Action<BnbApplicationCreationOptions>? action = null)
    {
        return BnbApplicationFactory.CreateAsync(startupModuleType, services,action);
    }


    public static string? GetApplicationName(this IServiceCollection services)
    {
        return services.GetSingletonInstance<IBnbApplicationInfoAccessor>().ApplicationName;
    }


    public static string GetApplicationInstanceId(this IServiceCollection services)
    {
        return services.GetSingletonInstance<IBnbApplicationInfoAccessor>().InstanceId;
    }
}