using Bonyan.Bnb.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace Bonyan.Bnb.Localization;

public class BnbLocalizationContext : IBnbServiceProviderAccessor
{
    public IServiceProvider ServiceProvider { get; }

    public IStringLocalizerFactory LocalizerFactory { get; }

    public BnbLocalizationContext(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        LocalizerFactory = ServiceProvider.GetRequiredService<IStringLocalizerFactory>();
    }
}
