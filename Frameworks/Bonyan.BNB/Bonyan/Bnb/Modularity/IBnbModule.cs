namespace Bonyan.Bnb.Modularity;

public interface IBnbModule
{
    void ConfigureServices(BnbServiceConfigurationContext context);
    Task ConfigureServicesAsync(BnbServiceConfigurationContext context);
}