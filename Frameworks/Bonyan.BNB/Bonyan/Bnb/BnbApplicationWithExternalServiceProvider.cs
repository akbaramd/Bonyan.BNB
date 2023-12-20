using Bonyan.Bnb.Exceptions;
using Bonyan.Bnb.Statics;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.Bnb;

internal class BnbApplicationWithExternalServiceProvider : BnbApplication, IBnbApplicationWithExternalServiceProvider
{
    public BnbApplicationWithExternalServiceProvider(
        Type startupModuleType,
        IServiceCollection services
        ,Action<BnbApplicationCreationOptions>? action = null
    ) : base(
        startupModuleType,
        services,action)
    {
        services.AddSingleton<IBnbApplicationWithExternalServiceProvider>(this);
    }

    void IBnbApplicationWithExternalServiceProvider.SetServiceProvider(IServiceProvider serviceProvider)
    {
        BnbCheck.NotNull(serviceProvider, nameof(serviceProvider));

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (ServiceProvider != null)
        {
            if (ServiceProvider != serviceProvider)
            {
                throw new BnbException("Service provider was already set before to another service provider instance.");
            }

            return;
        }

        SetServiceProvider(serviceProvider);
    }

    public async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        BnbCheck.NotNull(serviceProvider, nameof(serviceProvider));

        SetServiceProvider(serviceProvider);

        await InitializeModulesAsync();
    }

    public void Initialize(IServiceProvider serviceProvider)
    {
        BnbCheck.NotNull(serviceProvider, nameof(serviceProvider));

        SetServiceProvider(serviceProvider);

        InitializeModules();
    }

    public override void Dispose()
    {
        base.Dispose();

        if (ServiceProvider is IDisposable disposableServiceProvider)
        {
            disposableServiceProvider.Dispose();
        }
    }
}
