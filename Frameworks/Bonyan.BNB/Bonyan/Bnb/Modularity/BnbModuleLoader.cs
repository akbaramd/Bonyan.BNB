using Bonyan.Bnb.Exceptions;
using Bonyan.Bnb.Extensions;
using Bonyan.Bnb.Statics;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.Bnb.Modularity;

public class BnbModuleLoader : IBnbModuleLoader
{
    public IBnbModuleDescriptor[] LoadModules(
        IServiceCollection services,
        Type startupModuleType)
    {
        BnbCheck.NotNull(services, nameof(services));
        BnbCheck.NotNull(startupModuleType, nameof(startupModuleType));

        var modules = GetDescriptors(services, startupModuleType);

        modules = SortByDependency(modules, startupModuleType);

        return modules.ToArray();
    }

    private List<IBnbModuleDescriptor> GetDescriptors(
        IServiceCollection services,
        Type startupModuleType)
    {
        var modules = new List<BnbModuleDescriptor>();

        FillModules(modules, services, startupModuleType);
        SetDependencies(modules);

        return modules.Cast<IBnbModuleDescriptor>().ToList();
    }

    protected virtual void FillModules(
        List<BnbModuleDescriptor> modules,
        IServiceCollection services,
        Type startupModuleType)
    {

        //All modules starting from the startup module
        foreach (var moduleType in BnbModuleHelper.FindAllModuleTypes(startupModuleType))
        {
            modules.Add(CreateModuleDescriptor(services, moduleType));
        }

        // //Plugin modules
        // foreach (var moduleType in plugInSources.GetAllModules())
        // {
        //     if (modules.Any(m => m.Type == moduleType))
        //     {
        //         continue;
        //     }
        //
        //     modules.Add(CreateModuleDescriptor(services, moduleType, isLoadedAsPlugIn: true));
        // }
    }

    protected virtual void SetDependencies(List<BnbModuleDescriptor> modules)
    {
        foreach (var module in modules)
        {
            SetDependencies(modules, module);
        }
    }

    protected virtual List<IBnbModuleDescriptor> SortByDependency(List<IBnbModuleDescriptor> modules, Type startupModuleType)
    {
        var sortedModules = modules.SortByDependencies(m => m.Dependencies);
        sortedModules.MoveItem(m => m.Type == startupModuleType, modules.Count - 1);
        return sortedModules;
    }

    protected virtual BnbModuleDescriptor CreateModuleDescriptor(IServiceCollection services, Type moduleType, bool isLoadedAsPlugIn = false)
    {
        return new BnbModuleDescriptor(moduleType, CreateAndRegisterModule(services, moduleType), isLoadedAsPlugIn);
    }

    protected virtual IBnbModule CreateAndRegisterModule(IServiceCollection services, Type moduleType)
    {
        var module = (IBnbModule)Activator.CreateInstance(moduleType)!;
        services.AddSingleton(moduleType, module);
        return module;
    }

    protected virtual void SetDependencies(List<BnbModuleDescriptor> modules, BnbModuleDescriptor module)
    {
        foreach (var dependedModuleType in BnbModuleHelper.FindDependedModuleTypes(module.Type))
        {
            var dependedModule = modules.FirstOrDefault(m => m.Type == dependedModuleType);
            if (dependedModule == null)
            {
                throw new BnbException("Could not find a depended module " + dependedModuleType.AssemblyQualifiedName + " for " + module.Type.AssemblyQualifiedName);
            }

            module.AddDependency(dependedModule);
        }
    }
}
