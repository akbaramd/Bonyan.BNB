using Bonyan.Bnb.DependencyInjection;

namespace Bonyan.Bnb.Modularity;

public interface IBnbModuleManager : ISingletonDependency
{
    Task InitializeModulesAsync( BnbApplicationInitializationContext context);

    void InitializeModules(BnbApplicationInitializationContext context);

    Task ShutdownModulesAsync( BnbApplicationShutdownContext context);

    void ShutdownModules( BnbApplicationShutdownContext context);
}