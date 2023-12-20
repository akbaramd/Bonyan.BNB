using Bonyan.Bnb.Statics;

namespace Bonyan.Bnb.Modularity;

public class BnbApplicationInitializationContext : IServiceProviderAccessor
{
    public IServiceProvider ServiceProvider { get; set; }


    public BnbApplicationInitializationContext(IServiceProvider serviceProvider)
    {
        BnbCheck.NotNull(serviceProvider, nameof(serviceProvider));

        ServiceProvider = serviceProvider;
       
    }
}