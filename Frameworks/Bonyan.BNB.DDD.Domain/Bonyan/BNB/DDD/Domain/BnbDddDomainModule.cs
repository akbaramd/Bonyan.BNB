using Bonyan.BNB.DDD.Domain.Repository;
using Bonyan.Bnb.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.BNB.DDD.Domain;

public class BnbDddDomainModule : BnbModule
{
    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
        
    }
}