using Bonyan.Bnb.Attributes;
using Bonyan.BNB.DDD.Domain;
using Bonyan.Bnb.Modularity;

namespace Bonyan.BNB.Identity.Domain;

[DependsOnModules(typeof(BnbDddDomainModule))]
public class BnbIdentityDomainModule : BnbModule
{
    
}