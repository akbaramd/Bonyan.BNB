using Bonyan.Bnb.Statics;

namespace Bonyan.Bnb.Modularity;

public class BnbApplicationShutdownContext
{
    public IServiceProvider ServiceProvider { get; }

    public BnbApplicationShutdownContext(IServiceProvider serviceProvider)
    {
        BnbCheck.NotNull(serviceProvider, nameof(serviceProvider));

        ServiceProvider = serviceProvider;
    }
}
