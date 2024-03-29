﻿namespace Bonyan.Bnb.DependencyInjection;

[ExposeServices(typeof(ITransientCachedServiceProvider))]
public class TransientCachedServiceProvider :
    CachedServiceProviderBase,
    ITransientCachedServiceProvider,
    ITransientDependency
{
    public TransientCachedServiceProvider(IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
    }
}