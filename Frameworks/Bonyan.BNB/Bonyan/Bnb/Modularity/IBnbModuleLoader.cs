using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.Bnb.Modularity;

public interface IBnbModuleLoader
{
    IBnbModuleDescriptor[] LoadModules(
        IServiceCollection services,
        Type startupModuleType
    );
}