using Bonyan.Bnb.Modularity;

namespace Bonyan.Bnb;

public interface IBnbModuleContainer
{
    IReadOnlyCollection<IBnbModuleDescriptor> Modules { get; }
}