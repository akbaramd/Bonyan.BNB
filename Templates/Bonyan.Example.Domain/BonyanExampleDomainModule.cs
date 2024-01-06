using Bonyan.Bnb.Attributes;
using Bonyan.BNB.DDD.Domain;
using Bonyan.BNB.Identity.Domain;
using Bonyan.Bnb.Modularity;
using Bonyan.Example.Domain.DomainServices;
using Bonyan.Example.Domain.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.Example.Domain;

[DependsOnModules(
    typeof(BnbDddDomainModule),
    typeof(BnbIdentityDomainModule)
    ,typeof(BonyanExampleDomainSharedModule))]
public class BonyanExampleDomainModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.AddScoped(typeof(UserManager));
        base.ConfigureServices(context);
    }
}