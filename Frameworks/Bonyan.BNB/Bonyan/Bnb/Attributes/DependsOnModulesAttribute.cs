using Bonyan.Bnb.Modularity;

namespace Bonyan.Bnb.Attributes;

public class DependsOnModulesAttribute : Attribute , IBnbDependedTypesProvider
{
    public Type[] DependedTypes { get; }

    public DependsOnModulesAttribute(params Type[]? dependedTypes)
    {
        DependedTypes = dependedTypes ?? Type.EmptyTypes;
    }

    public virtual Type[] GetDependedTypes()
    {
        return DependedTypes;
    }
}