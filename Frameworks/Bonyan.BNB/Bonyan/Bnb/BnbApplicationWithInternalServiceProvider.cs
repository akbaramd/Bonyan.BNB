using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.Bnb;

internal class BnbApplicationWithInternalServiceProvider : BnbApplication, IBnbApplicationWithInternalServiceProvider
{
    public IServiceScope? ServiceScope { get; private set; }

    public BnbApplicationWithInternalServiceProvider(
        Type startupModuleType,
        Action<BnbApplicationCreationOptions>? optionsAction
    ) : this(
        startupModuleType,
        new ServiceCollection(),
        optionsAction)
    {
    }

    private BnbApplicationWithInternalServiceProvider(
         Type startupModuleType,
         IServiceCollection services,
        Action<BnbApplicationCreationOptions>? optionsAction
    ) : base(
        startupModuleType,
        services,
        optionsAction)
    {
        Services.AddSingleton<IBnbApplicationWithInternalServiceProvider>(this);
    }

    public IServiceProvider CreateServiceProvider()
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (ServiceProvider != null)
        {
            return ServiceProvider;
        }

        ServiceScope = Services.BuildServiceProviderFromFactory().CreateScope();
        SetServiceProvider(ServiceScope.ServiceProvider);

        return ServiceProvider!;
    }

    public async Task InitializeAsync()
    {
        CreateServiceProvider();
        await InitializeModulesAsync();
    }

    public void Initialize()
    {
        CreateServiceProvider();
        InitializeModules();
    }

    public override void Dispose()
    {
        base.Dispose();
        ServiceScope?.Dispose();
    }
}
