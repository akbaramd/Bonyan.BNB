using System.Reflection;
using Bonyan.Bnb.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.Bnb.Modularity;

public abstract class BnbModule : IBnbModule, IOnPreApplicationInitialization,
    IOnBnbApplicationInitialization,
    IOnPostBnbApplicationInitialization,
    IOnBnbApplicationShutdown,
    IPreBnbConfigureServices,
    IPostBnbConfigureServices
{

    protected internal bool SkipAutoServiceRegistration { get; protected set; }
    
    protected internal BnbServiceConfigurationContext BnbServiceConfigurationContext {
        get {
            if (_serviceConfigurationContext == null)
            {
                throw new BnbException($"{nameof(BnbServiceConfigurationContext)} is only available in the {nameof(ConfigureServices)}, {nameof(PreConfigureServices)} and {nameof(PostConfigureServices)} methods.");
            }

            return _serviceConfigurationContext;
        }
        internal set => _serviceConfigurationContext = value;
    }
    
    private BnbServiceConfigurationContext? _serviceConfigurationContext;
    internal static void CheckBnbModuleType(Type moduleType)
    {
        if (!IsBnbModule(moduleType))
        {
            throw new ArgumentException("Given type is not an ENT module: " + moduleType.AssemblyQualifiedName);
        }
    }
    
    public static bool IsBnbModule(Type type)
    {
        var typeInfo = type.GetTypeInfo();

        return
            typeInfo.IsClass &&
            !typeInfo.IsAbstract &&
       
            typeof(IBnbModule).GetTypeInfo().IsAssignableFrom(type);
    }

    public virtual Task PreConfigureServicesAsync(BnbServiceConfigurationContext context)
    {
        PreConfigureServices(context);
        return Task.CompletedTask;
    }

    public virtual void PreConfigureServices(BnbServiceConfigurationContext context)
    {

    }

    public virtual Task ConfigureServicesAsync(BnbServiceConfigurationContext context)
    {
        ConfigureServices(context);
        return Task.CompletedTask;
    }

    public virtual void ConfigureServices(BnbServiceConfigurationContext context)
    {

    }

    public virtual Task PostConfigureServicesAsync(BnbServiceConfigurationContext context)
    {
        PostConfigureServices(context);
        return Task.CompletedTask;
    }

    public virtual void PostConfigureServices(BnbServiceConfigurationContext context)
    {

    }

    public virtual Task OnPreApplicationInitializationAsync(BnbApplicationInitializationContext context)
    {
        OnPreApplicationInitialization(context);
        return Task.CompletedTask;
    }

    public virtual void OnPreApplicationInitialization(BnbApplicationInitializationContext context)
    {

    }

    public virtual Task OnApplicationInitializationAsync(BnbApplicationInitializationContext context)
    {
        OnApplicationInitialization(context);
        return Task.CompletedTask;
    }

    public virtual void OnApplicationInitialization(BnbApplicationInitializationContext context)
    {

    }

    public virtual Task OnPostApplicationInitializationAsync(BnbApplicationInitializationContext context)
    {
        OnPostApplicationInitialization(context);
        return Task.CompletedTask;
    }

    public virtual void OnPostApplicationInitialization(BnbApplicationInitializationContext context)
    {

    }

    public virtual Task OnApplicationShutdownAsync(BnbApplicationShutdownContext context)
    {
        OnApplicationShutdown(context);
        return Task.CompletedTask;
    }

    public virtual void OnApplicationShutdown(BnbApplicationShutdownContext context)
    {

    }
    
    
    
    protected void Configure<TOptions>(Action<TOptions> configureOptions)
        where TOptions : class
    {
        BnbServiceConfigurationContext.Services.Configure(configureOptions);
    }

    protected void Configure<TOptions>(string name, Action<TOptions> configureOptions)
        where TOptions : class
    {
        try
        {
           BnbServiceConfigurationContext.Services.Configure(name, configureOptions);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    protected void Configure<TOptions>(IConfiguration configuration)
        where TOptions : class
    {
        BnbServiceConfigurationContext.Services.Configure<TOptions>(configuration);
    }

    protected void Configure<TOptions>(IConfiguration configuration, Action<BinderOptions> configureBinder)
        where TOptions : class
    {
        BnbServiceConfigurationContext.Services.Configure<TOptions>(configuration, configureBinder);
    }

    protected void Configure<TOptions>(string name, IConfiguration configuration)
        where TOptions : class
    {
        BnbServiceConfigurationContext.Services.Configure<TOptions>(name, configuration);
    }

    protected void PreConfigure<TOptions>(Action<TOptions> configureOptions)
        where TOptions : class
    {
        // ServiceConfigurationContext.Services.PreConfigure(configureOptions);
    }

    protected void PostConfigure<TOptions>(Action<TOptions> configureOptions)
        where TOptions : class
    {
        BnbServiceConfigurationContext.Services.PostConfigure(configureOptions);
    }

    protected void PostConfigureAll<TOptions>(Action<TOptions> configureOptions)
        where TOptions : class
    {
        BnbServiceConfigurationContext.Services.PostConfigureAll(configureOptions);
    }
}