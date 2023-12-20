namespace Bonyan.Bnb.Modularity;

public class OnBnbApplicationInitializationModuleLifecycleContributor : BnbModuleLifecycleContributorBase
{
    public async override Task InitializeAsync(BnbApplicationInitializationContext context, IBnbModule module)
    {
        if (module is IOnBnbApplicationInitialization onApplicationInitialization)
        {
            await onApplicationInitialization.OnApplicationInitializationAsync(context);
        }
    }

    public override void Initialize(BnbApplicationInitializationContext context, IBnbModule module)
    {
        (module as IOnBnbApplicationInitialization)?.OnApplicationInitialization(context);
    }
}

public class OnBnbApplicationShutdownModuleLifecycleContributor : BnbModuleLifecycleContributorBase
{
    public async override Task ShutdownAsync(BnbApplicationShutdownContext context, IBnbModule module)
    {
        if (module is IOnBnbApplicationShutdown onApplicationShutdown)
        {
            await onApplicationShutdown.OnApplicationShutdownAsync(context);
        }
    }

    public override void Shutdown(BnbApplicationShutdownContext context, IBnbModule module)
    {
        (module as IOnBnbApplicationShutdown)?.OnApplicationShutdown(context);
    }
}

public class OnBnbPreApplicationInitializationModuleLifecycleContributor : BnbModuleLifecycleContributorBase
{
    public async override Task InitializeAsync(BnbApplicationInitializationContext context, IBnbModule module)
    {
        if (module is IOnPreApplicationInitialization onPreApplicationInitialization)
        {
            await onPreApplicationInitialization.OnPreApplicationInitializationAsync(context);
        }
    }

    public override void Initialize(BnbApplicationInitializationContext context, IBnbModule module)
    {
        (module as IOnPreApplicationInitialization)?.OnPreApplicationInitialization(context);
    }
}

public class OnBnbPostApplicationInitializationModuleLifecycleContributor : BnbModuleLifecycleContributorBase
{
    public async override Task InitializeAsync(BnbApplicationInitializationContext context, IBnbModule module)
    {
        if (module is IOnPostBnbApplicationInitialization onPostApplicationInitialization)
        {
            await onPostApplicationInitialization.OnPostApplicationInitializationAsync(context);
        }
    }

    public override void Initialize(BnbApplicationInitializationContext context, IBnbModule module)
    {
        (module as IOnPostBnbApplicationInitialization)?.OnPostApplicationInitialization(context);
    }
}
