using Bonyan.Bnb.Modularity;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Bonyan.BNB.EntityFrameworkCore;

public class BnbEntityFrameworkCoreModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        Configure<BnbDbContextOptions>(options =>
        {
            options.PreConfigure(abpDbContextConfigurationContext =>
            {
                abpDbContextConfigurationContext.DbContextOptions
                    .ConfigureWarnings(warnings =>
                    {
                        warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning);
                    });
            });
        });
        base.ConfigureServices(context);
    }
}