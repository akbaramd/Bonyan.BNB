namespace Bonyan.Bnb.Modularity;

public abstract class BnbModuleLifecycleContributorBase : IBnbModuleLifecycleContributor
{
    public virtual Task InitializeAsync(BnbApplicationInitializationContext context, IBnbModule module)
    {
        return Task.CompletedTask;
    }

    public virtual void Initialize(BnbApplicationInitializationContext context, IBnbModule module)
    {
    }

    public virtual Task ShutdownAsync(BnbApplicationShutdownContext context, IBnbModule module)
    {
        return Task.CompletedTask;
    }

    public virtual void Shutdown(BnbApplicationShutdownContext context, IBnbModule module)
    {
    }
}
