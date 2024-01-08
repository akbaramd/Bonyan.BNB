using Bonyan.Bnb.Attributes;
using Bonyan.BNB.Identity.Application;
using Bonyan.Bnb.Identity.Options;
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
        Configure<BnbIdentityJwtOptions>(x =>
        {
            x.Audience = "Audience.com";
            x.Issuer = "Audience.com";
            x.ExpireMinutes = 5;
            x.SecretKey = "asdkjdasd63423*&(yhnaslasdasdasdasdasdkd";
        });
        base.ConfigureServices(context);
    }
}