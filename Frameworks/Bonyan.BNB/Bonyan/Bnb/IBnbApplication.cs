using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.Bnb;

public interface IBnbApplication: IBnbModuleContainer,IBnbApplicationInfoAccessor,IDisposable
{
    IServiceCollection Services { get; }
    IServiceProvider ServiceProvider { get; }
    
    Type StartupModuleType { get; }
    void ConfigureServices();
    Task ConfigureServicesAsync();
    Task ShutdownAsync();
    void Shutdown();
}