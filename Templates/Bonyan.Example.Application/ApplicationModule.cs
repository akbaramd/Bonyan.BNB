using Bonyan.Bnb.Attributes;
using Bonyan.BNB.Identity.Application;
using Bonyan.Bnb.Modularity;
using Bonyan.Example.Application.Contracts;
using Bonyan.Example.Domain;

namespace Bonyan.Example.Application;

[DependsOnModules(
    typeof(BnbIdentityApplicationModule),
    typeof(ApplicationContractsModule),
    typeof(DomainModule)
)]
public class ApplicationModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
    }
}