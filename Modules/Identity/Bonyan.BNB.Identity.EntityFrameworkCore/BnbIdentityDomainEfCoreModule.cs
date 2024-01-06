using Bonyan.Bnb.Attributes;
using Bonyan.BNB.EntityFrameworkCore;
using Bonyan.Bnb.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.BNB.Identity.EntityFrameworkCore;

[DependsOnModules(typeof(BnbEntityFrameworkCoreModule))]
public class BnbIdentityDomainEfCoreModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
      
        base.ConfigureServices(context);
    }
}