using Bonyan.Bnb.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bonyan.Bnb.Modularity;

public class BnbModuleManager : IBnbModuleManager 
{
    private readonly IBnbModuleContainer _bnbModuleContainer;
    private readonly IEnumerable<IBnbModuleLifecycleContributor> _lifecycleContributors;
    private readonly ILogger<BnbModuleManager> _logger;

    public BnbModuleManager(
        IBnbModuleContainer bnbModuleContainer,
        ILogger<BnbModuleManager> logger,
        IOptions<BnbModuleLifecycleOptions> options,
        IServiceProvider serviceProvider)
    {
        _bnbModuleContainer = bnbModuleContainer;
        _logger = logger;

        _lifecycleContributors = options.Value
            .Contributors
            .Select(serviceProvider.GetRequiredService)
            .Cast<IBnbModuleLifecycleContributor>()
            .ToArray();
    }

    public virtual async Task InitializeModulesAsync(BnbApplicationInitializationContext context)
    {
        _logger.LogInformation("Start InitializeAsync All Bnb Modules");
        foreach (var contributor in _lifecycleContributors)
        {
            foreach (var module in _bnbModuleContainer.Modules)
            {
                try
                {
                    await contributor.InitializeAsync(context, module.Instance);
                }
                catch (Exception ex)
                {
                    throw new BnbInitializationException($"An error occurred during the initialize {contributor.GetType().FullName} phase of the module {module.Type.AssemblyQualifiedName}: {ex.Message}. See the inner exception for details.", ex);
                }
            }
        }

        _logger.LogInformation("All Bnb Modules InitializeAsync ");
    }

    public void InitializeModules(BnbApplicationInitializationContext context)
    {
        _logger.LogInformation("Start Initialize All Bnb Modules");
        foreach (var contributor in _lifecycleContributors)
        {
            foreach (var module in _bnbModuleContainer.Modules)
            {
                try
                {
                    contributor.Initialize(context, module.Instance);
                }
                catch (Exception ex)
                {
                    throw new BnbInitializationException($"An error occurred during the initialize {contributor.GetType().FullName} phase of the module {module.Type.AssemblyQualifiedName}: {ex.Message}. See the inner exception for details.", ex);
                }
            }
        }

        _logger.LogInformation("All Bnb Modules Initlized ");
    }

    public virtual async Task ShutdownModulesAsync(BnbApplicationShutdownContext context)
    {
        var modules = _bnbModuleContainer.Modules.Reverse().ToList();

        foreach (var contributor in _lifecycleContributors)
        {
            foreach (var module in modules)
            {
                try
                {
                    await contributor.ShutdownAsync(context, module.Instance);
                }
                catch (Exception ex)
                {
                    throw new BnbInitializationException($"An error occurred during the shutdown {contributor.GetType().FullName} phase of the module {module.Type.AssemblyQualifiedName}: {ex.Message}. See the inner exception for details.", ex);
                }
            }
        }
    }

    public void ShutdownModules(BnbApplicationShutdownContext context)
    {
        var modules = _bnbModuleContainer.Modules.Reverse().ToList();

        foreach (var contributor in _lifecycleContributors)
        {
            foreach (var module in modules)
            {
                try
                {
                    contributor.Shutdown(context, module.Instance);
                }
                catch (Exception ex)
                {
                    throw new BnbInitializationException($"An error occurred during the shutdown {contributor.GetType().FullName} phase of the module {module.Type.AssemblyQualifiedName}: {ex.Message}. See the inner exception for details.", ex);
                }
            }
        }
    }
}