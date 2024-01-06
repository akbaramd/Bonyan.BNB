using Bonyan.BNB.DDD.Domain;
using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.BNB.DDD.Domain.Repository;
using Bonyan.Bnb.Exceptions;
using Bonyan.Bnb.Extensions;
using Bonyan.Bnb.Statics;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bonyan.BNB.EntityFrameworkCore;

public class BnbDbContextOptions
{
    internal List<Action<BnbDbContextConfigurationContext>> DefaultPreConfigureActions { get; }

    internal Action<BnbDbContextConfigurationContext>? DefaultConfigureAction { get; set; }

    internal Dictionary<Type, List<object>> PreConfigureActions { get; }

    internal Dictionary<Type, object> ConfigureActions { get; }


    public BnbDbContextOptions()
    {
        DefaultPreConfigureActions = new List<Action<BnbDbContextConfigurationContext>>();
        PreConfigureActions = new Dictionary<Type, List<object>>();
        ConfigureActions = new Dictionary<Type, object>();
    }

    public void PreConfigure([NotNull] Action<BnbDbContextConfigurationContext> action)
    {
        BnbCheck.NotNull(action, nameof(action));

        DefaultPreConfigureActions.Add(action);
    }

    public void Configure([NotNull] Action<BnbDbContextConfigurationContext> action)
    {
        BnbCheck.NotNull(action, nameof(action));

        DefaultConfigureAction = action;
    }

    public bool IsConfiguredDefault()
    {
        return DefaultConfigureAction != null;
    }

    public void PreConfigure<TDbContext>([NotNull] Action<BnbDbContextConfigurationContext<TDbContext>> action)
        where TDbContext : BnbDbContext<TDbContext>
    {
        BnbCheck.NotNull(action, nameof(action));

        var actions = PreConfigureActions.GetOrDefault(typeof(TDbContext));
        if (actions == null)
        {
            PreConfigureActions[typeof(TDbContext)] = actions = new List<object>();
        }

        actions.Add(action);
    }

    public void Configure<TDbContext>([NotNull] Action<BnbDbContextConfigurationContext<TDbContext>> action)
        where TDbContext : BnbDbContext<TDbContext>
    {
        BnbCheck.NotNull(action, nameof(action));

        ConfigureActions[typeof(TDbContext)] = action;
    }

    public bool IsConfigured<TDbContext>()
    {
        return IsConfigured(typeof(TDbContext));
    }

    public bool IsConfigured(Type dbContextType)
    {
        return ConfigureActions.ContainsKey(dbContextType);
    }

   
}