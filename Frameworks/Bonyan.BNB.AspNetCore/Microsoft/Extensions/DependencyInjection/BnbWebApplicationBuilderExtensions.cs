using Bonyan.Bnb;
using Bonyan.Bnb.Modularity;

namespace Bonyan.BNB.AspNetCore.Microsoft.Extensions.DependencyInjection;

public static class BnbWebApplicationBuilderExtensions
{
    public static Task<IBnbApplicationWithExternalServiceProvider> AddApplicationAsync<TStartupModule>(
        this WebApplicationBuilder builder,
        Action<BnbApplicationCreationOptions>? action = null)
        where TStartupModule : IBnbModule
    {
        return  builder.Services.AddApplicationAsync<TStartupModule>(action);
    }

    public static Task<IBnbApplicationWithExternalServiceProvider> AddApplicationAsync(
        this WebApplicationBuilder builder,
        Type startupModuleType,
        Action<BnbApplicationCreationOptions>? action = null)
    {
        return  builder.Services.AddApplicationAsync(startupModuleType,action);
    }
}