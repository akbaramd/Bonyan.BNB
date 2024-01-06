using Bonyan.Bnb.Extensions;
using Bonyan.Bnb.Statics;
using JetBrains.Annotations;

namespace Bonyan.BNB.EntityFrameworkCore;

public class BnbDbContextOptions
{
    internal List<Action<AbpDbContextConfigurationContext>> DefaultPreConfigureActions { get; }

    internal Action<AbpDbContextConfigurationContext>? DefaultConfigureAction { get; set; }

    internal Dictionary<Type, List<object>> PreConfigureActions { get; }

    internal Dictionary<Type, object> ConfigureActions { get; }


    public BnbDbContextOptions()
    {
        DefaultPreConfigureActions = new List<Action<AbpDbContextConfigurationContext>>();
        PreConfigureActions = new Dictionary<Type, List<object>>();
        ConfigureActions = new Dictionary<Type, object>();
    }

    public void PreConfigure( Action<AbpDbContextConfigurationContext> action)
    {
        BnbCheck.NotNull(action, nameof(action));

        DefaultPreConfigureActions.Add(action);
    }

    public void Configure([NotNull] Action<AbpDbContextConfigurationContext> action)
    {
        BnbCheck.NotNull(action, nameof(action));

        DefaultConfigureAction = action;
    }

    public bool IsConfiguredDefault()
    {
        return DefaultConfigureAction != null;
    }

    public void PreConfigure<TDbContext>([NotNull] Action<AbpDbContextConfigurationContext<TDbContext>> action)
        where TDbContext : BnbDbContext
    {
        BnbCheck.NotNull(action, nameof(action));

        var actions = PreConfigureActions.GetOrDefault(typeof(TDbContext));
        if (actions == null)
        {
            PreConfigureActions[typeof(TDbContext)] = actions = new List<object>();
        }

        actions.Add(action);
    }

    public void Configure<TDbContext>([NotNull] Action<AbpDbContextConfigurationContext<TDbContext>> action)
        where TDbContext : BnbDbContext
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