using Bonyan.Bnb.Statics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.Bnb;

public class BnbApplicationCreationOptions
{
    public IServiceCollection Services { get; }

    // public PlugInSourceList PlugInSources { get; }

    /// <summary>
    /// The options in this property only take effect when IConfiguration not registered.
    /// </summary>
    public BnbConfigurationBuilderOptions Configuration { get; }

    public bool SkipConfigureServices { get; set; }

    public string? ApplicationName { get; set; }

    public string? Environment { get; set; }

    public BnbApplicationCreationOptions(IServiceCollection services)
    {
        Services = BnbCheck.NotNull(services, nameof(services));
        // PlugInSources = new PlugInSourceList();
        Configuration = new BnbConfigurationBuilderOptions();
    }
}