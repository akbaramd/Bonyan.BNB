using System.Reflection;

namespace Bonyan.Bnb.Modularity;

public interface IAdditionalModuleAssemblyProvider
{
    Assembly[] GetAssemblies();
}