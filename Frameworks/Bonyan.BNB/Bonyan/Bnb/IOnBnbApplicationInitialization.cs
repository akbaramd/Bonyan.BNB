using Bonyan.Bnb.Modularity;

namespace Bonyan.Bnb;

public interface IOnBnbApplicationInitialization
{
    Task OnApplicationInitializationAsync(BnbApplicationInitializationContext context);

    void OnApplicationInitialization( BnbApplicationInitializationContext context);
}
