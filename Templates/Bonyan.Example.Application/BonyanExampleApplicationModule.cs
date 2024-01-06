using Bonyan.Bnb.Attributes;
using Bonyan.BNB.DDD.Application;
using Bonyan.BNB.Identity.Application;
using Bonyan.Bnb.Modularity;
using Bonyan.Example.Application.Contracts;
using Bonyan.Example.Domain;

namespace Bonyan.Example.Application;

[DependsOnModules(
    typeof(BonyanExampleDomainModule),
    typeof(BnbDddApplicationModule),
    typeof(BnbIdentityApplicationModule),
    typeof(BonyanExampleApplicationContractsModule))]
public class BonyanExampleApplicationModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
       
        base.ConfigureServices(context);
    }
}