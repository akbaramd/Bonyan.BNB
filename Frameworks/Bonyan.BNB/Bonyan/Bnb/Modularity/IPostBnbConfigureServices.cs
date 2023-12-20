namespace Bonyan.Bnb.Modularity;

public interface IPostBnbConfigureServices
{
    Task PostConfigureServicesAsync(BnbServiceConfigurationContext context);

    void PostConfigureServices(BnbServiceConfigurationContext context);
}
