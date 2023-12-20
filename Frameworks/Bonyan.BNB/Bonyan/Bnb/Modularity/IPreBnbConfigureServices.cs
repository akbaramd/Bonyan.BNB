namespace Bonyan.Bnb.Modularity;

public interface IPreBnbConfigureServices
{
    Task PreConfigureServicesAsync(BnbServiceConfigurationContext context);

    void PreConfigureServices(BnbServiceConfigurationContext context);
}
