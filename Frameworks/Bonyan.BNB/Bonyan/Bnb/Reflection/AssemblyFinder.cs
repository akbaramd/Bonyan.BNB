using System.Collections.Immutable;
using System.Reflection;

namespace Bonyan.Bnb.Reflection;

public class AssemblyFinder : IAssemblyFinder
{
    private readonly IBnbModuleContainer _bnbModuleContainer;

    private readonly Lazy<IReadOnlyList<Assembly>> _assemblies;

    public AssemblyFinder(IBnbModuleContainer bnbModuleContainer)
    {
        _bnbModuleContainer = bnbModuleContainer;

        _assemblies = new Lazy<IReadOnlyList<Assembly>>(FindAll, LazyThreadSafetyMode.ExecutionAndPublication);
    }

    public IReadOnlyList<Assembly> Assemblies => _assemblies.Value;

    public IReadOnlyList<Assembly> FindAll()
    {
        var assemblies = new List<Assembly>();

        foreach (var module in _bnbModuleContainer.Modules)
        {
            assemblies.AddRange(module.AllAssemblies);
        }

        return assemblies.Distinct().ToImmutableList();
    }
}
