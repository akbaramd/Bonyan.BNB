using System.Reflection;

namespace Bonyan.Bnb.Modularity;

public interface IBnbModuleDescriptor
{
    Type Type { get; }
    
    Assembly Assembly { get; }
    
    Assembly[] AllAssemblies { get; }
    
    IBnbModule Instance { get; }
    
    bool IsLoadedAsPlugIn { get; }
    
    IReadOnlyList<IBnbModuleDescriptor> Dependencies { get; }
}