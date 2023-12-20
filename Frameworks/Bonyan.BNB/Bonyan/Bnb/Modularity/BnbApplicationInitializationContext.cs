using Bonyan.Bnb.DependencyInjection;
using Bonyan.Bnb.Statics;

namespace Bonyan.Bnb.Modularity;

public class BnbApplicationInitializationContext : IBnbServiceProviderAccessor
{
    public IServiceProvider ServiceProvider { get; set; }


    public BnbApplicationInitializationContext(IServiceProvider serviceProvider)
    {
        BnbCheck.NotNull(serviceProvider, nameof(serviceProvider));

        ServiceProvider = serviceProvider;
       
    }
}