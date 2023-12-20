using Bonyan.Bnb.Modularity;

namespace Bonyan.Bnb;

public interface IOnBnbApplicationShutdown
{
    Task OnApplicationShutdownAsync(BnbApplicationShutdownContext context);

    void OnApplicationShutdown( BnbApplicationShutdownContext context);
}
