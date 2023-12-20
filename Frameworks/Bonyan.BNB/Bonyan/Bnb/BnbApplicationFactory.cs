using Bonyan.Bnb.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.Bnb;

public static class BnbApplicationFactory
{
    public static async Task<IBnbApplicationWithInternalServiceProvider> CreateAsync<TStartupModule>(
        Action<BnbApplicationCreationOptions>? optionsAction = null)
        where TStartupModule : IBnbModule
    {
        var app = Create(typeof(TStartupModule), options =>
        {
            options.SkipConfigureServices = true;
            optionsAction?.Invoke(options);
        });
        await app.ConfigureServicesAsync();
        return app;
    }

    public static async Task<IBnbApplicationWithInternalServiceProvider> CreateAsync(
        Type startupModuleType,
        Action<BnbApplicationCreationOptions>? optionsAction = null)
    {
        var app = new BnbApplicationWithInternalServiceProvider(startupModuleType, options =>
        {
            options.SkipConfigureServices = true;
            optionsAction?.Invoke(options);
        });
        await app.ConfigureServicesAsync();
        return app;
    }

    public static async Task<IBnbApplicationWithExternalServiceProvider> CreateAsync<TStartupModule>(
        IServiceCollection services,
        Action<BnbApplicationCreationOptions>? optionsAction = null)
        where TStartupModule : IBnbModule
    {
        var app = Create(typeof(TStartupModule), services, options =>
        {
            options.SkipConfigureServices = true;
            optionsAction?.Invoke(options);
        });
        await app.ConfigureServicesAsync();
        return app;
    }

    public static async Task<IBnbApplicationWithExternalServiceProvider> CreateAsync(
        Type startupModuleType,
        IServiceCollection services,
        Action<BnbApplicationCreationOptions>? optionsAction = null)
    {
        var app = new BnbApplicationWithExternalServiceProvider(startupModuleType, services, options =>
        {
            options.SkipConfigureServices = true;
            optionsAction?.Invoke(options);
        });
        await app.ConfigureServicesAsync();
        return app;
    }

    public static IBnbApplicationWithInternalServiceProvider Create<TStartupModule>(
        Action<BnbApplicationCreationOptions>? optionsAction = null)
        where TStartupModule : IBnbModule
    {
        return Create(typeof(TStartupModule), optionsAction);
    }

    public static IBnbApplicationWithInternalServiceProvider Create(
        Type startupModuleType,
        Action<BnbApplicationCreationOptions>? optionsAction = null)
    {
        return new BnbApplicationWithInternalServiceProvider(startupModuleType, optionsAction);
    }

    public static IBnbApplicationWithExternalServiceProvider Create<TStartupModule>(
        IServiceCollection services,
        Action<BnbApplicationCreationOptions>? optionsAction = null)
        where TStartupModule : IBnbModule
    {
        return Create(typeof(TStartupModule), services, optionsAction);
    }

    public static IBnbApplicationWithExternalServiceProvider Create(
        Type startupModuleType,
        IServiceCollection services,
        Action<BnbApplicationCreationOptions>? optionsAction = null)
    {
        return new BnbApplicationWithExternalServiceProvider(startupModuleType, services, optionsAction);
    }
}