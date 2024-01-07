using Bonyan.Bnb.Attributes;
using Bonyan.BNB.Identity.Domain;
using Bonyan.Bnb.Modularity;
using Bonyan.Example.Domain.Shared;

namespace Bonyan.Example.Domain;

[DependsOnModules(
    typeof(BnbIdentityDomainModule)
    ,typeof(DomainSharedModule))]
public class DomainModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
      
        base.ConfigureServices(context);
    }
}