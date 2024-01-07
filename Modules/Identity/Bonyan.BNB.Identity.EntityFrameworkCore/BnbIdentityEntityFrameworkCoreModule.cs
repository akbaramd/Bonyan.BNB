using Bonyan.Bnb.Attributes;
using Bonyan.BNB.EntityFrameworkCore;
using Bonyan.Bnb.Modularity;

namespace Bonyan.BNB.Identity.EntityFrameworkCore;

[DependsOnModules(typeof(BnbEntityFrameworkCoreModule))]
public class BnbIdentityEntityFrameworkCoreModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        
        base.ConfigureServices(context);
    }
}