using Bonyan.Bnb.Attributes;
using Bonyan.BNB.Identity.Application.Contracts;
using Bonyan.Bnb.Modularity;

namespace Bonyan.BNB.Identity.Api;

[DependsOnModules(typeof(BnbIdentityApplicationContractsModule))]
public class BnbIdentityApiModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
    }
}