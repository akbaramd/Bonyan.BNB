namespace Bonyan.BNB.Modularity;

public interface IBnbModule
{
    void ConfigureServices(ServiceConfigurationContext context);
    Task ConfigureServicesAsync(ServiceConfigurationContext context);
}