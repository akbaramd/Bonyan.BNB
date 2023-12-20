using System.Collections.Immutable;
using System.Reflection;
using Bonyan.Bnb.Extensions;
using Bonyan.Bnb.Statics;

namespace Bonyan.Bnb.Modularity;

public class BnbModuleDescriptor : IBnbModuleDescriptor
{
    private readonly List<IBnbModuleDescriptor> _dependencies;

    public BnbModuleDescriptor( Type type, IBnbModule instance, bool isLoadedAsPlugIn)
    {
        BnbCheck.NotNull(type, nameof(type));
        BnbCheck.NotNull(instance, nameof(instance));
        BnbModule.CheckBnbModuleType(type);
        if (!type.GetTypeInfo().IsAssignableFrom(instance.GetType()))
            throw new ArgumentException(
                $"Given module instance ({instance.GetType().AssemblyQualifiedName}) is not an instance of given module type: {type.AssemblyQualifiedName}");
        Type = type;
        Assembly = type.Assembly;
        AllAssemblies = BnbModuleHelper.GetAllAssemblies(type);
        Instance = instance;
        IsLoadedAsPlugIn = isLoadedAsPlugIn;
        _dependencies = new List<IBnbModuleDescriptor>();
    }

    public Type Type { get; }
    public Assembly Assembly { get; }
    public Assembly[] AllAssemblies { get; }
    public IBnbModule Instance { get; }
    public bool IsLoadedAsPlugIn { get; }
    public IReadOnlyList<IBnbModuleDescriptor> Dependencies => _dependencies.ToImmutableList();

    public void AddDependency(IBnbModuleDescriptor descriptor)
    {
        _dependencies.AddIfNotContains(descriptor);
    }

    public override string ToString()
    {
        return $"[BnbModuleDescriptor {Type.FullName}]";
    }
}