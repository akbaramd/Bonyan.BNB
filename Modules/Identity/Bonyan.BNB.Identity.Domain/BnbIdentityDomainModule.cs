using Bonyan.Bnb.Attributes;
using Bonyan.BNB.DDD.Domain;
using Bonyan.Bnb.Modularity;
using Bonyan.Example.Domain.DomainServices;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.BNB.Identity.Domain;

[DependsOnModules(typeof(BnbDddDomainModule))]
public class BnbIdentityDomainModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.AddTransient(typeof(UserManager));
        base.ConfigureServices(context);
    }
}