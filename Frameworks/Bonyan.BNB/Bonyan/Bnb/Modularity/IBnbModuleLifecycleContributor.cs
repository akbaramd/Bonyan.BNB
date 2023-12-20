using Bonyan.Bnb.DependencyInjection;

namespace Bonyan.Bnb.Modularity;

public interface IBnbModuleLifecycleContributor : ITransientDependency
{
    Task InitializeAsync(BnbApplicationInitializationContext context, IBnbModule module);

    void Initialize(BnbApplicationInitializationContext context, IBnbModule module);

    Task ShutdownAsync(BnbApplicationShutdownContext context, IBnbModule module);

    void Shutdown(BnbApplicationShutdownContext context, IBnbModule module);
}