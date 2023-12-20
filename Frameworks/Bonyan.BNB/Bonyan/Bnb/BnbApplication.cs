using System.Reflection;
using Bonyan.Bnb.DependencyInjection;
using Bonyan.Bnb.Exceptions;
using Bonyan.Bnb.Modularity;
using Bonyan.Bnb.Reflection;
using Bonyan.Bnb.Statics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Bonyan.Bnb;

public class BnbApplication : IBnbApplication
{
    private bool _configuredServices;

    internal BnbApplication(
        Type startupModuleType,
        IServiceCollection services, Action<BnbApplicationCreationOptions>? optionsAction = null)
    {
        BnbCheck.NotNull(startupModuleType, nameof(startupModuleType));
        BnbCheck.NotNull(services, nameof(services));

        var options = new BnbApplicationCreationOptions(services);
        optionsAction?.Invoke(options);

        AddCoreServices(services);

        services.TryAddObjectAccessor<IServiceProvider>();

        services.AddSingleton<IBnbApplication>(this);
        services.AddSingleton<IBnbApplicationInfoAccessor>(this);
        services.AddSingleton<IBnbModuleContainer>(this);
        services.AddSingleton<IBnbHostEnvironment>(new BnbHostEnvironment()
        {
            EnvironmentName = options.Environment
        });
        
        services.TryAddSingleton<IBnbModuleLoader>(new BnbModuleLoader());

        StartupModuleType = startupModuleType;
        Services = services;
        ApplicationName = GetApplicationName(options);
        Modules = LoadModules(services);

        var assemblyFinder = new AssemblyFinder(this);

        services.TryAddSingleton<IAssemblyFinder>(assemblyFinder);
        services.TryAddSingleton<ITypeFinder>(new TypeFinder(assemblyFinder));

        services.AddAssemblyOf<IBnbApplication>();

        services.Configure<BnbModuleLifecycleOptions>(lifecycleOptions =>
        {
            lifecycleOptions.Contributors.Add<OnBnbPreApplicationInitializationModuleLifecycleContributor>();
            lifecycleOptions.Contributors.Add<OnBnbApplicationInitializationModuleLifecycleContributor>();
            lifecycleOptions.Contributors.Add<OnBnbPostApplicationInitializationModuleLifecycleContributor>();
            lifecycleOptions.Contributors.Add<OnBnbApplicationShutdownModuleLifecycleContributor>();
        });

        if (!options.SkipConfigureServices) ConfigureServices();
    }


    public Type StartupModuleType { get; }

    public IServiceCollection Services { get; }
    public IServiceProvider ServiceProvider { get; private set; }
    public IReadOnlyCollection<IBnbModuleDescriptor> Modules { get; }
    public string? ApplicationName { get; }
    public string InstanceId { get; } = Guid.NewGuid().ToString();

    public async Task ShutdownAsync()
    {
        using var scope = ServiceProvider.CreateScope();

        await scope.ServiceProvider
            .GetRequiredService<IBnbModuleManager>()
            .ShutdownModulesAsync(new BnbApplicationShutdownContext(scope.ServiceProvider));
    }

    public void Shutdown()
    {
        using var scope = ServiceProvider.CreateScope();
        scope.ServiceProvider
            .GetRequiredService<IBnbModuleManager>()
            .ShutdownModules(new BnbApplicationShutdownContext(scope.ServiceProvider));
    }

    public virtual void Dispose()
    {
    } 


    public async Task ConfigureServicesAsync()
    {

        CheckMultipleConfigureServices();

        var context = new BnbServiceConfigurationContext(Services);
        Services.AddSingleton(context);

        foreach (var module in Modules)
            if (module.Instance is BnbModule entModule)
            {
                entModule.BnbServiceConfigurationContext = context;
            }

        //PreConfigureServices
        foreach (var module in Modules.Where(m => m.Instance is IPreBnbConfigureServices))
            try
            {
                await ((IPreBnbConfigureServices)module.Instance).PreConfigureServicesAsync(context);
            }
            catch (Exception ex)
            {
                throw new BnbInitializationException(
                    $"An error occurred during {nameof(IPreBnbConfigureServices.PreConfigureServicesAsync)} phase of the module {module.Type.AssemblyQualifiedName}. See the inner exception for details.",
                    ex);
            }

        var assemblies = new HashSet<Assembly>();

        //ConfigureServices
        foreach (var module in Modules)
        {
            if (module.Instance is BnbModule { SkipAutoServiceRegistration: false })
                foreach (var assembly in module.AllAssemblies)
                {
                    if (assemblies.Contains(assembly)) continue;
                    Services.AddAssembly(assembly);
                    assemblies.Add(assembly);
                }

            try
            {
                await module.Instance.ConfigureServicesAsync(context);
            }
            catch (Exception ex)
            {
                throw new BnbInitializationException(
                    $"An error occurred during {nameof(IBnbModule.ConfigureServicesAsync)} phase of the module {module.Type.AssemblyQualifiedName}. See the inner exception for details.",
                    ex);
            }
        }

        //PostConfigureServices
        foreach (var module in Modules.Where(m => m.Instance is IPostBnbConfigureServices))
            try
            {
                await ((IPostBnbConfigureServices)module.Instance).PostConfigureServicesAsync(context);
            }
            catch (Exception ex)
            {
                throw new BnbInitializationException(
                    $"An error occurred during {nameof(IPostBnbConfigureServices.PostConfigureServicesAsync)} phase of the module {module.Type.AssemblyQualifiedName}. See the inner exception for details.",
                    ex);
            }

        foreach (var module in Modules)
            if (module.Instance is BnbModule entModule)
                entModule.BnbServiceConfigurationContext = null!;

        _configuredServices = true;

        TryToSetEnvironment(Services);

        // Logger.LogInformation("All Bnb Modules Service ConfiguredAsync");
    }

    //TODO: We can extract a new class for this
    public void ConfigureServices()
    {
        // Logger.LogInformation("Start ConfiguredAsync All Module");

        CheckMultipleConfigureServices();

        var context = new BnbServiceConfigurationContext(Services);
        Services.AddSingleton(context);

        foreach (var module in Modules)
            if (module.Instance is BnbModule entModule)
            {
                entModule.BnbServiceConfigurationContext = context;
            }

        //PreConfigureServices
        foreach (var module in Modules.Where(m => m.Instance is IPreBnbConfigureServices))
            try
            {
                ((IPreBnbConfigureServices)module.Instance).PreConfigureServices(context);
            }
            catch (Exception ex)
            {
                throw new BnbInitializationException(
                    $"An error occurred during {nameof(IPreBnbConfigureServices.PreConfigureServices)} phase of the module {module.Type.AssemblyQualifiedName}. See the inner exception for details.",
                    ex);
            }

        var assemblies = new HashSet<Assembly>();

        //ConfigureServices
        foreach (var module in Modules)
        {
            if (module.Instance is BnbModule { SkipAutoServiceRegistration: false })
                foreach (var assembly in module.AllAssemblies)
                    if (!assemblies.Contains(assembly))
                    {
                        Services.AddAssembly(assembly);
                        assemblies.Add(assembly);
                    }

            try
            {
                module.Instance.ConfigureServices(context);
            }
            catch (Exception ex)
            {
                throw new BnbInitializationException(
                    $"An error occurred during {nameof(IBnbModule.ConfigureServices)} phase of the module {module.Type.AssemblyQualifiedName}. See the inner exception for details.",
                    ex);
            }
        }

        //PostConfigureServices
        foreach (var module in Modules.Where(m => m.Instance is IPostBnbConfigureServices))
            try
            {
                ((IPostBnbConfigureServices)module.Instance).PostConfigureServices(context);
            }
            catch (Exception ex)
            {
                throw new BnbInitializationException(
                    $"An error occurred during {nameof(IPostBnbConfigureServices.PostConfigureServices)} phase of the module {module.Type.AssemblyQualifiedName}. See the inner exception for details.",
                    ex);
            }

        foreach (var module in Modules)
            if (module.Instance is BnbModule entModule)
                entModule.BnbServiceConfigurationContext = null!;

        _configuredServices = true;

        TryToSetEnvironment(Services);

        // Logger.LogInformation("All Bnb Modules Service Configured. \n");
    }

    private static void AddCoreServices(IServiceCollection services)
    {
        services.AddOptions();
        services.AddLogging();
        services.AddLocalization();
    }


    protected void SetServiceProvider(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        ServiceProvider.GetRequiredService<ObjectAccessor<IServiceProvider>>().Value = ServiceProvider;
    }

    protected async Task InitializeModulesAsync()
    {
        using var scope = ServiceProvider.CreateScope();
        var manager = scope.ServiceProvider
            .GetRequiredService<IBnbModuleManager>();

        await manager.InitializeModulesAsync(new BnbApplicationInitializationContext(scope.ServiceProvider));
    }

    protected void InitializeModules()
    {
        using var scope = ServiceProvider.CreateScope();
        // WriteInitLogs(scope.ServiceProvider);
        var manager = scope.ServiceProvider
            .GetRequiredService<IBnbModuleManager>();

        manager.InitializeModules(new BnbApplicationInitializationContext(scope.ServiceProvider));
    }

    private IReadOnlyList<IBnbModuleDescriptor> LoadModules(IServiceCollection services)
    {
        return services
            .GetSingletonInstance<IBnbModuleLoader>()
            .LoadModules(
                services,
                StartupModuleType
            );
    }


    private static string? GetApplicationName(BnbApplicationCreationOptions options)
    {
        if (!string.IsNullOrWhiteSpace(options.ApplicationName))
        {
            return options.ApplicationName!;
        }

        var configuration = options.Services.GetConfigurationOrNull();
        if (configuration != null)
        {
            var appNameConfig = configuration["ApplicationName"];
            if (!string.IsNullOrWhiteSpace(appNameConfig))
            {
                return appNameConfig!;
            }
        }

        var entryAssembly = Assembly.GetEntryAssembly();
        if (entryAssembly != null)
        {
            return entryAssembly.GetName().Name;
        }

        return null;
    }

    private void CheckMultipleConfigureServices()
    {
        if (_configuredServices)
            throw new BnbInitializationException(
                "Services have already been configured! If you call ConfigureServicesAsync method, you must have set BnbApplicationCreationOptions.SkipConfigureServices to true before.");
    }

    private static void TryToSetEnvironment(IServiceCollection services)
    {
        var abpHostEnvironment = services.GetSingletonInstance<IBnbHostEnvironment>();
        if (abpHostEnvironment.EnvironmentName.IsNullOrWhiteSpace())
            abpHostEnvironment.EnvironmentName = Environments.Production;
    }
}